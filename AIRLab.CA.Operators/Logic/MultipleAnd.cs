using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    /// <summary>
    /// Logical conjunction
    /// </summary>
    public class MultipleAnd : MultipleOperator, INode<bool>
    {
        public MultipleAnd(params INode[] childs)
            : base(typeof(bool), Expression.AndAlso, " ∧ ", childs)
        { }
    }
}