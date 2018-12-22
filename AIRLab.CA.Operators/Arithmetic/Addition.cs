using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Addition : BinaryOperator
    {
        public Addition(Type type, INode child1, INode child2)
            : base(type, child1, child2, Expression.Add, "({0}+{1})")
        { }
    }

    public class Addition<T> : Addition, INode<T>
    {
        public Addition(INode child1, INode child2)
            : base(typeof(T), child1, child2)
        { }
    }
}