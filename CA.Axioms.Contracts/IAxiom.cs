﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System.Collections.Generic;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface IAxiom
    {
        IReadOnlyCollection<string> Tags { get; }
        IEnumerable<ISelectOutput> Select(params INode[] roots);
        IEnumerable<IWhereOutput> SelectWhere(params INode[] roots);
        INode[] Apply(IWhereOutput instance);
    }
}