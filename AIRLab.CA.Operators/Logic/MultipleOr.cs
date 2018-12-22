using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    /// <summary>
    /// Logical disjunction
    /// </summary>
    public class MultipleOr : MultipleOperator, INode<bool>
    {
        public MultipleOr(params INode[] childs)
            : base(typeof(bool), Expression.OrElse, " ∨ ", childs)
        { }
    }
}