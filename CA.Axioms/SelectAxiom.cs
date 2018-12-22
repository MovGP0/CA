// ComputerAlgebra Library

// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at

namespace AIRLab.CA.Axioms
{
    public class SelectAxiom : ISelectAxiom
    {
        public IComplexSelector Selector { get; }
        public INewAxiom NewAxiom { get; }

        public SelectAxiom(INewAxiom newAxiom, IComplexSelector selector)
        {
            Selector = selector;
            NewAxiom = newAxiom;
        }
    }
}
