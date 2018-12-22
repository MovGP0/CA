using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    public class And : BinaryOperator, INode<bool>
    {
        public And(INode child1, INode child2)
            : base(typeof(bool), child1, child2, Expression.AndAlso, "({0}) ∧ ({1})")
        { }
    }
}