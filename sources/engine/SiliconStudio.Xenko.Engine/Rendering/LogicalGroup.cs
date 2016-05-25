using SiliconStudio.Core.Storage;

namespace SiliconStudio.Xenko.Rendering
{
    /// <summary>
    /// Defines a group of descriptors and cbuffer range that are updated together.
    /// It can be declared in shader using the syntax <c>cbuffer PerView_LogicalGroupName</c> (also works with <c>rgroup</c>).
    /// </summary>
    public struct LogicalGroup
    {
        public ObjectId Hash;

        public int DescriptorEntryStart;
        public int DescriptorEntryCount;
        public int DescriptorSlotStart;
        public int DescriptorSlotCount;

        public int ConstantBufferMemberStart;
        public int ConstantBufferMemberCount;
        public int ConstantBufferOffset;
        public int ConstantBufferSize;
    }
}