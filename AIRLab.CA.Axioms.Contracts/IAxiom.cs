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