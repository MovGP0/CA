using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Arithmetic
{
    public class Ln : UnaryFunction, INode<double>
    {
        public Ln(INode child)
            : base(typeof(double), child, typeof(Math).GetMethod("Log", new[] { typeof(double) }), "ln({0})")
        { }
    }
}
