using System;
using System.Linq;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    /// <summary>
    /// Implementation of functions in first-order logic. Contstants are functions without children.
    /// </summary>
    public class FunctionNode : TermNode
    {
        public FunctionNode(string name, params INode[] childs)
            : base(name, childs)
        {
        }

        public override Expression BuildExpression()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Children.Length == 0 ? Name : Name + "(" + string.Join(",", Children.Select(z => z.ToString())) + ")";
        }
    }
}
