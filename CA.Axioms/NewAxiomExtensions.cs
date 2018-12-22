// ComputerAlgebra Library

// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at

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