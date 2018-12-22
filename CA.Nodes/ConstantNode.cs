// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Collections;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    public sealed class Constant<T> : Constant, INode<T>
    {
        public Constant(T data) : base(typeof(T), data) { }
        public T Value => (T)Data;
    }

    public class Constant : Node
    {
        protected readonly object Data;

        protected Constant(Type type, object data) : base(0)
        {
            Data = data;
            Type = type;
        }

        public override Expression BuildExpression()
        {
            return Expression.Lambda(Expression.Constant(Data, Type), Expression.Parameter(typeof(IList)));
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}