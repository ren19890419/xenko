﻿#if SILICONSTUDIO_XENKO_GRAPHICS_API_DIRECT3D
//------------------------------------------------------------------------------
// <auto-generated>
//     Xenko Effect Compiler File Generated:
//     Effect [SpriteBatch]
//
//     Command Line: C:\Dev\Xenko\Master\sources\engine\SiliconStudio.Xenko.Graphics\Shaders.Bytecodes\..\..\..\..\Bin\Windows-Direct3D11\SiliconStudio.Assets.CompilerApp.exe --profile=Windows --graphics-platform=Direct3D11 --platform=Windows --output-path=C:\Dev\Xenko\Master\sources\engine\SiliconStudio.Xenko.Graphics\Shaders.Bytecodes\obj\app_data --build-path=C:\Dev\Xenko\Master\sources\engine\SiliconStudio.Xenko.Graphics\Shaders.Bytecodes\obj\build_app_data --package-file=Graphics.xkpkg
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiliconStudio.Xenko.Graphics 
{
    public partial class SpriteBatch
    {
        private static readonly byte[] binaryBytecode = new byte[] {
1, 192, 254, 239, 0, 6, 0, 0, 0, 17, 83, 112, 114, 105, 116, 101, 66, 97, 116, 99, 104, 83, 104, 97, 100, 101, 114, 1, 26, 42, 173, 201, 7, 31, 84, 101, 160, 181, 61, 143, 36, 194, 120, 155, 10, 83, 112, 114, 105, 116, 101, 66, 97, 115, 101, 1, 24, 122, 117, 12, 177, 182, 110, 250, 252, 
51, 21, 105, 61, 219, 225, 104, 10, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 1, 76, 31, 25, 215, 193, 29, 168, 182, 119, 159, 125, 91, 210, 35, 12, 84, 16, 83, 104, 97, 100, 101, 114, 66, 97, 115, 101, 83, 116, 114, 101, 97, 109, 1, 252, 149, 143, 37, 199, 91, 237, 34, 31, 232, 194, 
67, 83, 107, 157, 134, 9, 84, 101, 120, 116, 117, 114, 105, 110, 103, 1, 90, 7, 144, 56, 150, 36, 71, 168, 103, 101, 181, 74, 154, 179, 90, 203, 12, 67, 111, 108, 111, 114, 85, 116, 105, 108, 105, 116, 121, 1, 77, 232, 0, 156, 217, 55, 64, 161, 231, 217, 185, 133, 139, 109, 6, 40, 0, 0, 
1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 26, 83, 112, 114, 105, 116, 101, 66, 97, 115, 101, 46, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 0, 0, 0, 0, 1, 0, 20, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 95, 105, 100, 55, 
50, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 64, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 1, 0, 7, 80, 101, 114, 68, 114, 97, 119, 64, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 7, 80, 101, 
114, 68, 114, 97, 119, 0, 0, 0, 0, 0, 7, 80, 101, 114, 68, 114, 97, 119, 0, 7, 80, 101, 114, 68, 114, 97, 119, 10, 0, 0, 0, 26, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 17, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 83, 97, 109, 112, 108, 
101, 114, 0, 0, 0, 0, 1, 0, 12, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 52, 49, 8, 0, 0, 0, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 18, 84, 101, 120, 116, 117, 114, 105, 110, 103, 46, 84, 101, 120, 116, 117, 114, 101, 48, 0, 0, 0, 
0, 1, 0, 13, 84, 101, 120, 116, 117, 114, 101, 48, 95, 105, 100, 49, 51, 9, 0, 0, 0, 7, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 252, 
4, 0, 0, 68, 88, 66, 67, 202, 223, 238, 201, 217, 172, 150, 100, 155, 190, 188, 67, 114, 188, 184, 152, 1, 0, 0, 0, 252, 4, 0, 0, 6, 0, 0, 0, 56, 0, 0, 0, 48, 1, 0, 0, 116, 2, 0, 0, 240, 2, 0, 0, 200, 3, 0, 0, 96, 4, 0, 0, 65, 111, 110, 57, 240, 
0, 0, 0, 240, 0, 0, 0, 0, 2, 254, 255, 188, 0, 0, 0, 52, 0, 0, 0, 1, 0, 36, 0, 0, 0, 48, 0, 0, 0, 48, 0, 0, 0, 36, 0, 1, 0, 48, 0, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 254, 255, 31, 0, 0, 2, 5, 
0, 0, 128, 0, 0, 15, 144, 31, 0, 0, 2, 5, 0, 1, 128, 1, 0, 15, 144, 31, 0, 0, 2, 5, 0, 2, 128, 2, 0, 15, 144, 31, 0, 0, 2, 5, 0, 3, 128, 3, 0, 15, 144, 9, 0, 0, 3, 0, 0, 4, 192, 0, 0, 228, 144, 3, 0, 228, 160, 9, 0, 0, 3, 0, 
0, 1, 128, 0, 0, 228, 144, 1, 0, 228, 160, 9, 0, 0, 3, 0, 0, 2, 128, 0, 0, 228, 144, 2, 0, 228, 160, 9, 0, 0, 3, 0, 0, 4, 128, 0, 0, 228, 144, 4, 0, 228, 160, 4, 0, 0, 4, 0, 0, 3, 192, 0, 0, 170, 128, 0, 0, 228, 160, 0, 0, 228, 128, 1, 
0, 0, 2, 0, 0, 8, 192, 0, 0, 170, 128, 1, 0, 0, 2, 0, 0, 15, 224, 1, 0, 228, 144, 1, 0, 0, 2, 1, 0, 1, 224, 2, 0, 0, 144, 1, 0, 0, 2, 1, 0, 6, 224, 3, 0, 208, 144, 255, 255, 0, 0, 83, 72, 68, 82, 60, 1, 0, 0, 64, 0, 1, 0, 79, 
0, 0, 0, 89, 0, 0, 4, 70, 142, 32, 0, 0, 0, 0, 0, 4, 0, 0, 0, 95, 0, 0, 3, 242, 16, 16, 0, 0, 0, 0, 0, 95, 0, 0, 3, 242, 16, 16, 0, 1, 0, 0, 0, 95, 0, 0, 3, 18, 16, 16, 0, 2, 0, 0, 0, 95, 0, 0, 3, 50, 16, 16, 0, 3, 
0, 0, 0, 103, 0, 0, 4, 242, 32, 16, 0, 0, 0, 0, 0, 1, 0, 0, 0, 101, 0, 0, 3, 242, 32, 16, 0, 1, 0, 0, 0, 101, 0, 0, 3, 18, 32, 16, 0, 2, 0, 0, 0, 101, 0, 0, 3, 98, 32, 16, 0, 2, 0, 0, 0, 17, 0, 0, 8, 18, 32, 16, 0, 0, 
0, 0, 0, 70, 30, 16, 0, 0, 0, 0, 0, 70, 142, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 0, 8, 34, 32, 16, 0, 0, 0, 0, 0, 70, 30, 16, 0, 0, 0, 0, 0, 70, 142, 32, 0, 0, 0, 0, 0, 1, 0, 0, 0, 17, 0, 0, 8, 66, 32, 16, 0, 0, 
0, 0, 0, 70, 30, 16, 0, 0, 0, 0, 0, 70, 142, 32, 0, 0, 0, 0, 0, 2, 0, 0, 0, 17, 0, 0, 8, 130, 32, 16, 0, 0, 0, 0, 0, 70, 30, 16, 0, 0, 0, 0, 0, 70, 142, 32, 0, 0, 0, 0, 0, 3, 0, 0, 0, 54, 0, 0, 5, 242, 32, 16, 0, 1, 
0, 0, 0, 70, 30, 16, 0, 1, 0, 0, 0, 54, 0, 0, 5, 18, 32, 16, 0, 2, 0, 0, 0, 10, 16, 16, 0, 2, 0, 0, 0, 54, 0, 0, 5, 98, 32, 16, 0, 2, 0, 0, 0, 6, 17, 16, 0, 3, 0, 0, 0, 62, 0, 0, 1, 83, 84, 65, 84, 116, 0, 0, 0, 8, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 68, 69, 70, 208, 0, 0, 0, 1, 0, 0, 0, 68, 
0, 0, 0, 1, 0, 0, 0, 28, 0, 0, 0, 0, 4, 254, 255, 0, 65, 0, 0, 156, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 80, 101, 114, 68, 114, 97, 119, 0, 60, 
0, 0, 0, 1, 0, 0, 0, 92, 0, 0, 0, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 116, 0, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 2, 0, 0, 0, 140, 0, 0, 0, 0, 0, 0, 0, 77, 97, 116, 114, 105, 120, 84, 114, 97, 110, 115, 102, 111, 114, 109, 95, 105, 
100, 55, 50, 0, 171, 171, 171, 3, 0, 3, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77, 105, 99, 114, 111, 115, 111, 102, 116, 32, 40, 82, 41, 32, 72, 76, 83, 76, 32, 83, 104, 97, 100, 101, 114, 32, 67, 111, 109, 112, 105, 108, 101, 114, 32, 54, 46, 51, 46, 57, 54, 
48, 48, 46, 49, 54, 51, 56, 52, 0, 171, 171, 73, 83, 71, 78, 144, 0, 0, 0, 4, 0, 0, 0, 8, 0, 0, 0, 104, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 15, 15, 0, 0, 113, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 
0, 0, 0, 1, 0, 0, 0, 15, 15, 0, 0, 119, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 3, 0, 0, 80, 79, 83, 73, 84, 
73, 79, 78, 0, 67, 79, 76, 79, 82, 0, 66, 65, 84, 67, 72, 95, 83, 87, 73, 90, 90, 76, 69, 0, 84, 69, 88, 67, 79, 79, 82, 68, 0, 171, 171, 79, 83, 71, 78, 148, 0, 0, 0, 4, 0, 0, 0, 8, 0, 0, 0, 104, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 
0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 116, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 15, 0, 0, 0, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 1, 14, 0, 0, 136, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 6, 9, 0, 0, 83, 86, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 67, 79, 76, 79, 82, 0, 66, 65, 84, 67, 72, 95, 83, 87, 73, 90, 90, 76, 69, 0, 84, 69, 88, 67, 79, 79, 82, 68, 0, 171, 171, 171, 1, 
158, 66, 161, 246, 95, 170, 151, 42, 90, 49, 105, 135, 72, 150, 188, 15, 0, 5, 0, 0, 0, 0, 216, 3, 0, 0, 68, 88, 66, 67, 145, 51, 140, 120, 86, 99, 253, 98, 77, 57, 2, 3, 110, 52, 174, 135, 1, 0, 0, 0, 216, 3, 0, 0, 6, 0, 0, 0, 56, 0, 0, 0, 240, 0, 
0, 0, 216, 1, 0, 0, 84, 2, 0, 0, 8, 3, 0, 0, 164, 3, 0, 0, 65, 111, 110, 57, 176, 0, 0, 0, 176, 0, 0, 0, 0, 2, 255, 255, 136, 0, 0, 0, 40, 0, 0, 0, 0, 0, 40, 0, 0, 0, 40, 0, 0, 0, 40, 0, 1, 0, 36, 0, 0, 0, 40, 0, 0, 0, 
0, 0, 0, 2, 255, 255, 31, 0, 0, 2, 0, 0, 0, 128, 0, 0, 15, 176, 31, 0, 0, 2, 0, 0, 0, 128, 1, 0, 7, 176, 31, 0, 0, 2, 0, 0, 0, 144, 0, 8, 15, 160, 1, 0, 0, 2, 0, 0, 3, 128, 1, 0, 201, 176, 66, 0, 0, 3, 0, 0, 15, 128, 0, 0, 
228, 128, 0, 8, 228, 160, 5, 0, 0, 3, 1, 0, 8, 128, 1, 0, 0, 176, 1, 0, 0, 176, 88, 0, 0, 4, 0, 0, 15, 128, 1, 0, 255, 129, 0, 0, 228, 128, 0, 0, 0, 128, 5, 0, 0, 3, 0, 0, 15, 128, 0, 0, 228, 128, 0, 0, 228, 176, 1, 0, 0, 2, 0, 8, 
15, 128, 0, 0, 228, 128, 255, 255, 0, 0, 83, 72, 68, 82, 224, 0, 0, 0, 64, 0, 0, 0, 56, 0, 0, 0, 90, 0, 0, 3, 0, 96, 16, 0, 0, 0, 0, 0, 88, 24, 0, 4, 0, 112, 16, 0, 0, 0, 0, 0, 85, 85, 0, 0, 98, 16, 0, 3, 242, 16, 16, 0, 1, 0, 
0, 0, 98, 16, 0, 3, 18, 16, 16, 0, 2, 0, 0, 0, 98, 16, 0, 3, 98, 16, 16, 0, 2, 0, 0, 0, 101, 0, 0, 3, 242, 32, 16, 0, 0, 0, 0, 0, 104, 0, 0, 2, 2, 0, 0, 0, 24, 0, 0, 7, 18, 0, 16, 0, 0, 0, 0, 0, 10, 16, 16, 0, 2, 0, 
0, 0, 1, 64, 0, 0, 0, 0, 0, 0, 69, 0, 0, 9, 242, 0, 16, 0, 1, 0, 0, 0, 150, 21, 16, 0, 2, 0, 0, 0, 70, 126, 16, 0, 0, 0, 0, 0, 0, 96, 16, 0, 0, 0, 0, 0, 55, 0, 0, 9, 242, 0, 16, 0, 0, 0, 0, 0, 6, 0, 16, 0, 0, 0, 
0, 0, 70, 14, 16, 0, 1, 0, 0, 0, 6, 0, 16, 0, 1, 0, 0, 0, 56, 0, 0, 7, 242, 32, 16, 0, 0, 0, 0, 0, 70, 14, 16, 0, 0, 0, 0, 0, 70, 30, 16, 0, 1, 0, 0, 0, 62, 0, 0, 1, 83, 84, 65, 84, 116, 0, 0, 0, 5, 0, 0, 0, 2, 0, 
0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 68, 69, 70, 172, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 
0, 0, 28, 0, 0, 0, 0, 4, 255, 255, 0, 65, 0, 0, 119, 0, 0, 0, 92, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 2, 0, 0, 0, 5, 0, 0, 0, 4, 0, 
0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 1, 0, 0, 0, 12, 0, 0, 0, 83, 97, 109, 112, 108, 101, 114, 95, 105, 100, 52, 49, 0, 84, 101, 120, 116, 117, 114, 101, 48, 95, 105, 100, 49, 51, 0, 77, 105, 99, 114, 111, 115, 111, 102, 116, 32, 40, 82, 41, 32, 72, 76, 83, 76, 32, 
83, 104, 97, 100, 101, 114, 32, 67, 111, 109, 112, 105, 108, 101, 114, 32, 54, 46, 51, 46, 57, 54, 48, 48, 46, 49, 54, 51, 56, 52, 0, 171, 171, 171, 73, 83, 71, 78, 148, 0, 0, 0, 4, 0, 0, 0, 8, 0, 0, 0, 104, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 
0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 116, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 15, 15, 0, 0, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 136, 0, 0, 0, 0, 0, 
0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 6, 6, 0, 0, 83, 86, 95, 80, 111, 115, 105, 116, 105, 111, 110, 0, 67, 79, 76, 79, 82, 0, 66, 65, 84, 67, 72, 95, 83, 87, 73, 90, 90, 76, 69, 0, 84, 69, 88, 67, 79, 79, 82, 68, 0, 171, 171, 171, 79, 83, 
71, 78, 44, 0, 0, 0, 1, 0, 0, 0, 8, 0, 0, 0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 83, 86, 95, 84, 97, 114, 103, 101, 116, 0, 171, 171, 1, 224, 217, 33, 205, 173, 111, 179, 156, 201, 169, 38, 60, 168, 
66, 125, 121, 
        };
    }
}
#endif
