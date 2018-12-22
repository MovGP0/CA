﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

namespace AIRLab.CA.Nodes
{
    /// <summary>
    /// Implementation of Terms in first-order logic.
    /// </summary>
    public interface ITermNode : INode<bool>
    {
        /// <summary>
        /// The name of the term.
        /// </summary>
        string Name { get; }
    }
}
