using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public class SelectOutput : ISelectOutput
    {
        public INode[] SelectedNodes { get; private set; }
        public INode[] Roots { get; private set; }

        public SelectOutput(INode[] selectedNodes, INode[] roots)
        {
            SelectedNodes = selectedNodes;
            Roots = roots;
        }
    }
}
