// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

namespace AIRLab.CA.Axioms
{
    public interface ISelectAxiom
    {
        INewAxiom NewAxiom { get; }
        IComplexSelector Selector { get; }
    }
}