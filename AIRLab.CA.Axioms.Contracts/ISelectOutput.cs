using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface ISelectOutput
    {
        INode[] SelectedNodes { get; }
        INode[] Roots { get; }
    }
}