using System.Collections.Generic;

namespace AIRLab.CA.Axioms
{
    public interface ISelectClauseNode
    {
        IEnumerable<ISelectClauseNode> GetList();
        int Letter { get; }
        LetterRecursionType Recursive { get; }
        IList<ISelectClauseNode> Children { get; }
        ISelectClauseNode Parent { get; set; }

        ISelectClauseNode this[params ISelectClauseNode[] args] { get; }
    }
}