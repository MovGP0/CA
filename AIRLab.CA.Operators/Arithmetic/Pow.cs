using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Pow<T> : Pow, INode<T>
    {
        public Pow(INode child1, INode child2)
            : base(typeof(T), child1, child2)
        { }
    }

    public class Pow : BinaryOperator
    {
        public Pow(Type type, INode child1, INode child2)
            : base(type, child1, child2, Expression.Power, "({0})^({1})")
        { }
    }
}