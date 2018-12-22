using System;
using System.Linq;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    /// <summary>
    /// Class for predicates. In first-order logic predicated are not terms, but in this case they are.
    /// </summary>
    public class PredicateNode : TermNode
    {
        public PredicateNode(string name, params INode[] childs)
             : base(name, childs)
        { }

        public override Expression BuildExpression()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name + "(" + string.Join(",", Children.Select(z => z.ToString())) + ")";
        }
    }
}
