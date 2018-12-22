using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    public abstract class TermNode : Node, ITermNode
    {
        public string Name { get; }

        protected TermNode(string name, params INode[] childs)
             : base(childs)
        {
            Name = name;
        }
    }
}
