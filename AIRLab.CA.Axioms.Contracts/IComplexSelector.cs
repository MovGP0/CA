using System.Collections.Generic;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public interface IComplexSelector
    {
        IEnumerable<ISelectOutput> Select(params INode[] roots);
    }
}