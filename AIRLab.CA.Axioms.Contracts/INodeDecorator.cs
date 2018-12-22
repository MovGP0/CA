using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface INodeDecorator<out T>
        where T : INode
    {
        void Replace(INode newNode);
        T Node { get; }
        INode InitialParent { get; }
        int InitialIndex { get; }
        IModInput Instance { get; }
    }
}