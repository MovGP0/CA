using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    /// <summary>
    /// Negation
    /// </summary>
    public class Not : UnaryOperator, INode<bool>
    {
        public Not(INode child)
            : base(typeof(bool), child, Expression.Not, "¬({0})")
        { }
    }
}