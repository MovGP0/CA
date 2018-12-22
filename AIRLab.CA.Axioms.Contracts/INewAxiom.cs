using System.Collections.Generic;

namespace AIRLab.CA.Axioms
{
    public interface INewAxiom
    {
        string Name { get; }
        IEnumerable<string> Tags { get; }
    }
}