using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Sin : UnaryFunction, INode<double>
    {
        public Sin(INode child)
            : base(typeof(double), child, typeof(Math).GetMethod("Sin"), "sin({1})")
        { }
    }
}