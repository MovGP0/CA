using System;
using System.Collections;
using System.Linq.Expressions;

namespace AIRLab.CA.Nodes
{
    public class VariableNode : TermNode
    {
        public int Index { get; }

        public VariableNode(Type type, int index, string name) : base(name)
        {
            Index = index;
            Type = type;
        }

        public static VariableNode Make<T>(int index, string name)
        {
            return new VariableNode(typeof(T), index, name);
        }

        public override Expression BuildExpression()
        {
            var arguments = Expression.Parameter(typeof(IList));
            var called = Expression.Call(arguments, typeof(IList).GetMethod("get_Item"), Expression.Constant(Index));
            var converted = Expression.Convert(called, Type);
            var block = Expression.Block(converted);
            return Expression.Lambda(block, arguments);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}