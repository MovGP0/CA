// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Operators.Logic
{
    /// <summary>
    /// Negation
    /// </summary>
    public class Not : UnaryOperator, INode<bool>
    {
        public Not(INode child)
            : base(typeof(bool), child, Expression.Not, "¬({0})")
        { }
    }
}