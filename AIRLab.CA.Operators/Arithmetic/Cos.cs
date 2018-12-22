using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Cos : UnaryFunction, INode<double>
    {
        public Cos(INode child)
            : base(typeof(double), child, typeof(Math).GetMethod("Cos"), "cos({0})")
        { }
    }
}