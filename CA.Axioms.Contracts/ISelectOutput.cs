﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface ISelectOutput
    {
        INode[] SelectedNodes { get; }
        INode[] Roots { get; }
    }
}