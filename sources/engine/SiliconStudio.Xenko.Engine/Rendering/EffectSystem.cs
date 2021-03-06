﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SiliconStudio.Core;
using SiliconStudio.Core.Diagnostics;
using SiliconStudio.Core.Extensions;
using SiliconStudio.Core.IO;
using SiliconStudio.Core.ReferenceCounting;
using SiliconStudio.Core.Serialization.Assets;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Engine.Design;
using SiliconStudio.Xenko.Games;
using SiliconStudio.Xenko.Graphics;
using SiliconStudio.Xenko.Shaders;
using SiliconStudio.Xenko.Shaders.Compiler;

namespace SiliconStudio.Xenko.Rendering
{
    /// <summary>
    /// The effect system.
    /// </summary>
    public class EffectSystem : GameSystemBase
    {
        private readonly static Logger Log = GlobalLogger.GetLogger("EffectSystem");

        private EffectCompilerParameters effectCompilerParameters = EffectCompilerParameters.Default;

        private IGraphicsDeviceService graphicsDeviceService;
        private EffectCompilerBase compiler;
        private readonly Dictionary<string, List<CompilerResults>> earlyCompilerCache = new Dictionary<string, List<CompilerResults>>();
        private Dictionary<EffectBytecode, Effect> cachedEffects = new Dictionary<EffectBytecode, Effect>();
#if SILICONSTUDIO_PLATFORM_WINDOWS_DESKTOP
        private DirectoryWatcher directoryWatcher;
#endif
        private bool isInitialized;

        /// <summary>
        /// Called each time a non-cached effect is requested.
        /// </summary>
        internal Action<EffectCompileRequest> EffectUsed;

        private readonly HashSet<string> recentlyModifiedShaders = new HashSet<string>();

        public IEffectCompiler Compiler { get { return compiler; } set { compiler = (EffectCompilerBase)value; } }

        /// <summary>
        /// Gets or sets the database file provider, to use for loading effects and shader sources.
        /// </summary>
        /// <value>
        /// The database file provider.
        /// </value>
        public IVirtualFileProvider FileProvider
        {
            get { return compiler.FileProvider ?? ContentManager.FileProvider; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EffectSystem"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public EffectSystem(IServiceRegistry services)
            : base(services)
        {
            Services.AddService(typeof(EffectSystem), this);
        }

        public override void Initialize()
        {
            base.Initialize();

            isInitialized = true;

            // Get graphics device service
            graphicsDeviceService = Services.GetSafeServiceAs<IGraphicsDeviceService>();

#if SILICONSTUDIO_PLATFORM_WINDOWS_DESKTOP
            Enabled = true;
            directoryWatcher = new DirectoryWatcher("*.xksl");
            directoryWatcher.Modified += FileModifiedEvent;
            // TODO: xkfx too
#endif

            // Setup shader compiler settings from a compilation mode. 
            // TODO: We might want to provide overrides on the GameSettings to specify debug and/or optim level specifically.
            if (Game != null && (((Game)Game).Settings != null))
            {
                effectCompilerParameters.ApplyCompilationMode(((Game)Game).Settings.CompilationMode);
            }

            // Make sure default compiler is created (local if possible otherwise none) if nothing else was explicitely set/requested (i.e. by GameSettings)
            if (Compiler == null)
                Compiler = CreateEffectCompiler();
        }

        protected override void Destroy()
        {
            // Mark effect system as destroyed (so that async effect compilation are ignored)
            lock (cachedEffects)
            {
                // Clear effects
                foreach (var effect in cachedEffects)
                {
                    effect.Value.ReleaseInternal();
                }
                cachedEffects.Clear();

                // Mark as not initialized anymore
                isInitialized = false;
            }

#if SILICONSTUDIO_PLATFORM_WINDOWS_DESKTOP
            if (directoryWatcher != null)
            {
                directoryWatcher.Modified -= FileModifiedEvent;
                directoryWatcher.Dispose();
                directoryWatcher = null;
            }
#endif

            base.Destroy();
        }

        /// <summary>
        /// Creates an effect compiler, with either specificed <see cref="effectCompiler"/> or default one, wrapped in an <see cref="EffectCompilerCache"/>.
        /// </summary>
        /// <param name="effectCompiler">The effect compiler.</param>
        /// <param name="taskSchedulerSelector">The task scheduler selector.</param>
        /// <returns></returns>
        public static IEffectCompiler CreateEffectCompiler(TaskSchedulerSelector taskSchedulerSelector = null)
        {
            return CreateEffectCompiler(null, null, EffectCompilationMode.Local, false, taskSchedulerSelector);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            UpdateEffects();
        }

        public bool IsValid(Effect effect)
        {
            lock (cachedEffects)
            {
                return cachedEffects.ContainsKey(effect.Bytecode);
            }
        }
        
        /// <summary>
        /// Loads the effect.
        /// </summary>
        /// <param name="effectName">Name of the effect.</param>
        /// <param name="compilerParameters">The compiler parameters.</param>
        /// <param name="usedParameters">The used parameters.</param>
        /// <returns>A new instance of an effect.</returns>
        /// <exception cref="System.InvalidOperationException">Could not compile shader. Need fallback.</exception>
        public TaskOrResult<Effect> LoadEffect(string effectName, CompilerParameters compilerParameters)
        {
            if (effectName == null) throw new ArgumentNullException("effectName");
            if (compilerParameters == null) throw new ArgumentNullException("compilerParameters");

            // Setup compilation parameters
            // GraphicsDevice might have been not valid until this point, which is why we set this only here
            effectCompilerParameters.Platform = GraphicsDevice.Platform;
            effectCompilerParameters.Profile = GraphicsDevice.ShaderProfile ?? GraphicsDevice.Features.RequestedProfile;
            compilerParameters.EffectParameters = effectCompilerParameters;

            // Get the compiled result
            var compilerResult = GetCompilerResults(effectName, compilerParameters);
            CheckResult(compilerResult);

            // Only take the sub-effect
            var bytecode = compilerResult.Bytecode;

            if (bytecode.Task != null && !bytecode.Task.IsCompleted)
            {
                // Result was async, keep it async
                return bytecode.Task.ContinueWith(x => CreateEffect(effectName, x.Result, compilerResult));
            }
            else
            {
                return CreateEffect(effectName, bytecode.WaitForResult(), compilerResult);
            }
        }

        // TODO: THIS IS JUST A WORKAROUND, REMOVE THIS

        private static void CheckResult(LoggerResult compilerResult)
        {
            // Check errors
            if (compilerResult.HasErrors)
            {
                throw new InvalidOperationException("Could not compile shader. See error messages." + compilerResult.ToText());
            }
        }

        private Effect CreateEffect(string effectName, EffectBytecodeCompilerResult effectBytecodeCompilerResult, CompilerResults compilerResult)
        {
            Effect effect;
            lock (cachedEffects)
            {
                if (!isInitialized)
                    throw new ObjectDisposedException(nameof(EffectSystem), "EffectSystem has been disposed. This Effect compilation has been cancelled.");

                if (effectBytecodeCompilerResult.CompilationLog.HasErrors)
                {
                    // Unregister result (or should we keep it so that failure never change?)
                    List<CompilerResults> effectCompilerResults;
                    if (earlyCompilerCache.TryGetValue(effectName, out effectCompilerResults))
                    {
                        effectCompilerResults.Remove(compilerResult);
                    }
                }

                CheckResult(effectBytecodeCompilerResult.CompilationLog);

                var bytecode = effectBytecodeCompilerResult.Bytecode;
                if (bytecode == null)
                    throw new InvalidOperationException("EffectCompiler returned no shader and no compilation error.");

                if (!cachedEffects.TryGetValue(bytecode, out effect))
                {
                    effect = new Effect(graphicsDeviceService.GraphicsDevice, bytecode) { Name = effectName };
                    cachedEffects.Add(bytecode, effect);

#if SILICONSTUDIO_PLATFORM_WINDOWS_DESKTOP
                    foreach (var type in bytecode.HashSources.Keys)
                    {
                        // TODO: the "/path" is hardcoded, used in ImportStreamCommand and ShaderSourceManager. Find a place to share this correctly.
                        using (var pathStream = FileProvider.OpenStream(EffectCompilerBase.GetStoragePathFromShaderType(type) + "/path", VirtualFileMode.Open, VirtualFileAccess.Read))
                        using (var reader = new StreamReader(pathStream))
                        {
                            var path = reader.ReadToEnd();
                            directoryWatcher.Track(path);
                        }
                    }
#endif
                }
            }
            return effect;
        }

        private CompilerResults GetCompilerResults(string effectName, CompilerParameters compilerParameters)
        {
            // Compile shader
            var isXkfx = ShaderMixinManager.Contains(effectName);

            // getting the effect from the used parameters only makes sense when the source files are the same
            // TODO: improve this by updating earlyCompilerCache - cache can still be relevant

            CompilerResults compilerResult = null;

            if (isXkfx)
            {
                // perform an early test only based on the parameters
                compilerResult = GetShaderFromParameters(effectName, compilerParameters);
            }

            if (compilerResult == null)
            {
                var effectRequested = EffectUsed;
                if (effectRequested != null)
                {
                    effectRequested(new EffectCompileRequest(effectName, new CompilerParameters(compilerParameters)));
                }

                var source = isXkfx ? new ShaderMixinGeneratorSource(effectName) : (ShaderSource)new ShaderClassSource(effectName);
                compilerResult = compiler.Compile(source, compilerParameters);
                
                if (!compilerResult.HasErrors && isXkfx)
                {
                    lock (earlyCompilerCache)
                    {
                        List<CompilerResults> effectCompilerResults;
                        if (!earlyCompilerCache.TryGetValue(effectName, out effectCompilerResults))
                        {
                            effectCompilerResults = new List<CompilerResults>();
                            earlyCompilerCache.Add(effectName, effectCompilerResults);
                        }

                        // Register bytecode used parameters so that they are checked when another effect is instanced
                        effectCompilerResults.Add(compilerResult);
                    }
                }
            }

            foreach (var message in compilerResult.Messages)
            {
                Log.Log(message);
            }

            return compilerResult;
        }

        private void UpdateEffects()
        {
            lock (recentlyModifiedShaders)
            {
                if (recentlyModifiedShaders.Count == 0)
                {
                    return;
                }

                // Clear cache for recently modified shaders
                compiler.ResetCache(recentlyModifiedShaders);

                var bytecodeRemoved = new List<EffectBytecode>();

                lock (cachedEffects)
                {
                    foreach (var shaderSourceName in recentlyModifiedShaders)
                    {
                        // TODO: cache keys in a HashSet instead of ToHashSet
                        var bytecodes = new HashSet<EffectBytecode>(cachedEffects.Keys);
                        foreach (var bytecode in bytecodes)
                        {
                            if (bytecode.HashSources.ContainsKey(shaderSourceName))
                            {
                                bytecodeRemoved.Add(bytecode);

                                // Dispose previous effect
                                var effect = cachedEffects[bytecode];
                                //todo should be reference counted instead of disposed
                                effect.Dispose();
                                effect.SourceChanged = true;

                                // Remove effect from cache
                                cachedEffects.Remove(bytecode);
                            }
                        }
                    }
                }

                lock (earlyCompilerCache)
                {
                    foreach (var effectCompilerResults in earlyCompilerCache.Values)
                    {
                        foreach (var bytecode in bytecodeRemoved)
                        {
                            effectCompilerResults.RemoveAll(results => results.Bytecode.GetCurrentResult().Bytecode == bytecode);
                        }
                    }
                }

                recentlyModifiedShaders.Clear();
            }
        }

        private void FileModifiedEvent(object sender, FileEvent e)
        {
            if (e.ChangeType == FileEventChangeType.Changed || e.ChangeType == FileEventChangeType.Renamed)
            {
                lock (recentlyModifiedShaders)
                {
                    recentlyModifiedShaders.Add(Path.GetFileNameWithoutExtension(e.Name));
                }
            }
        }

        /// <summary>
        /// Get the shader from the database based on the parameters used for its compilation.
        /// </summary>
        /// <param name="effectName">Name of the effect.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The EffectBytecode if found.</returns>
        protected CompilerResults GetShaderFromParameters(string effectName, CompilerParameters parameters)
        {
            lock (earlyCompilerCache)
            {
                List<CompilerResults> compilerResultsList;
                if (!earlyCompilerCache.TryGetValue(effectName, out compilerResultsList))
                    return null;

                // Compiler Parameters are supposed to be created in the same order every time, so we just check if they were created in the same order (ParameterKeyInfos) with same values (ObjectValues)
                
                // TODO GRAPHICS REFACTOR we could probably compute a hash for faster lookup
                foreach (var compiledResults in compilerResultsList)
                {
                    var compiledParameters = compiledResults.SourceParameters;

                    var compiledParameterKeyInfos = compiledParameters.ParameterKeyInfos;
                    var parameterKeyInfos = parameters.ParameterKeyInfos;

                    // Early check
                    if (parameterKeyInfos.Count != compiledParameterKeyInfos.Count)
                        continue;

                    for (int index = 0; index < parameterKeyInfos.Count; ++index)
                    {
                        var parameterKeyInfo = parameterKeyInfos[index];
                        var compiledParameterKeyInfo = compiledParameterKeyInfos[index];

                        if (parameterKeyInfo != compiledParameterKeyInfo)
                            goto different;

                        // Should not happen in practice (CompilerParameters should only consist of permutation values)
                        if (parameterKeyInfo.Key.Type != ParameterKeyType.Permutation)
                            continue;

                        for (int i = 0; i < parameterKeyInfo.Count; ++i)
                        {
                            var object1 = parameters.ObjectValues[parameterKeyInfo.BindingSlot + i];
                            var object2 = compiledParameters.ObjectValues[compiledParameterKeyInfo.BindingSlot + i];
                            if (object1 == null && object2 == null)
                                continue;
                            if ((object1 == null && object2 != null) || (object2 == null && object1 != null))
                                goto different;
                            if (!object1.Equals(object2))
                                goto different;
                        }
                    }

                    return compiledResults;

                different:
                    ;
                }
            }

            return null;
        }

        internal static IEffectCompiler CreateEffectCompiler(EffectSystem effectSystem, Guid? packageId, EffectCompilationMode effectCompilationMode, bool recordEffectRequested, TaskSchedulerSelector taskSchedulerSelector = null)
        {
            EffectCompilerBase compiler = null;

#if SILICONSTUDIO_XENKO_EFFECT_COMPILER
            if ((effectCompilationMode & EffectCompilationMode.Local) != 0)
            {
                // Local allowed and available, let's use that
                compiler = new EffectCompiler
                {
                    SourceDirectories = { EffectCompilerBase.DefaultSourceShaderFolder },
                };
            }
#endif

            // Nothing to do remotely
            bool needRemoteCompiler = (compiler == null && (effectCompilationMode & EffectCompilationMode.Remote) != 0);
            if (needRemoteCompiler || recordEffectRequested)
            {
                // Create the object that handles the connection
                var shaderCompilerTarget = new RemoteEffectCompilerClient(packageId);

                if (recordEffectRequested)
                {
                    // Let's notify effect compiler server for each new effect requested
                    effectSystem.EffectUsed += shaderCompilerTarget.NotifyEffectUsed;
                }

                // Use remote only if nothing else was found before (i.e. a local compiler)
                if (needRemoteCompiler)
                {
                    // Create a remote compiler
                    compiler = new RemoteEffectCompiler(shaderCompilerTarget);
                }
            }

            // Local not possible or allowed, and remote not allowed either => switch back to null compiler
            if (compiler == null)
            {
                compiler = new NullEffectCompiler();
            }

            return new EffectCompilerCache(compiler, taskSchedulerSelector);
        }
    }
}
