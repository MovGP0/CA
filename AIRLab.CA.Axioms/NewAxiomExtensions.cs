namespace AIRLab.CA.Axioms
{
    public static class NewAxiomExtensions
    {
        public static ISelectAxiom Select(this INewAxiom axiom, params ISelectClauseNode[] clauses)
        {
            return new SelectAxiom(axiom, new ComplexSelector(clauses));
        }
    }
}