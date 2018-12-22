﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

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