using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Divide<T> : Divide, INode<T>
    {
        public Divide(INode child1, INode child2)
            : base(typeof(T), child1, child2)
        { }
    }

    public class Divide : BinaryOperator
    {
        public Divide(Type type, INode child1, INode child2)
            : base(type, child1, child2, Expression.Divide, "({0})/({1})")
        { }
    }
}