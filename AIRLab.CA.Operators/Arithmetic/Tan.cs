using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Tan : UnaryFunction, INode<double>
    {
        public Tan(INode child)
            : base(typeof(double), child, typeof(Math).GetMethod("Tan"), "tan({1})")
        { }
    }
}