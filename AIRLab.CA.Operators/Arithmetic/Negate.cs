using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Negate : UnaryOperator
    {
        public Negate(Type type, INode child)
            : base(type, child, Expression.Negate, "-({0})")
        { }
    }

    public class Negate<T> : Negate, INode<T>
    {
        public Negate(INode child)
            : base(typeof(T), child)
        { }
    }
}