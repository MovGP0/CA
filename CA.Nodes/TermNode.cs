// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    public abstract class TermNode : Node, ITermNode
    {
        public string Name { get; }

        protected TermNode(string name, params INode[] childs)
             :base(childs)
        {
            Name = name;
        }
    }
}
