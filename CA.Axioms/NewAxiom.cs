// ComputerAlgebra Library

// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at

using System.Collections.Generic;

namespace AIRLab.CA.Axioms
{
    public class NewAxiom : INewAxiom
    {
        public string Name { get; }
        public IEnumerable<string> Tags { get; }
        public NewAxiom(string name, IEnumerable<string> tags)
        {
            Name = name;
            Tags = tags;
        }
    }
}
