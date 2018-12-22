using System.Collections.Generic;

namespace AIRLab.CA.Nodes
{
    public interface IChildrenCollection : IEnumerable<INode>
    {
        INode this[int index] { get; set; }
        int Length { get; }
        void ReleaseChild(int index);
        INode[] ChildrenArray { get; set; }
    }
}