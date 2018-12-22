using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Differentiation
{
    /// <summary>
    /// ordinary differential equation
    /// </summary>
    public class Dif<T> : Dif, INode<T>
    {
        public Dif(INode child1, VariableNode child2)
            : base(typeof(T), child1, child2)
        { }
    }

    /// <summary>
    /// ordinary differential equation
    /// </summary>
    public class Dif : BinaryOperator
    {
        public Dif(Type type, INode child1, VariableNode child2)
            : base(type, child1, child2, Expression.Add, "{0}´({1})")
        { }
    }
}