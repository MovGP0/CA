using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    /// <summary>
    /// Logical disjunction
    /// </summary>
    public class Or : BinaryOperator, INode<bool>
    {
        public Or(INode child1, INode child2)
            : base(typeof(bool), child1, child2, Expression.OrElse, "({0})∨({1})")
        { }
    }
}