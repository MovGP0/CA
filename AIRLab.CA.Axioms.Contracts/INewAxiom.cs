// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System.Collections.Generic;

namespace AIRLab.CA.Axioms
{
    public interface INewAxiom
    {
        string Name { get; }
        IEnumerable<string> Tags { get; }
    }
}