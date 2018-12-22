namespace AIRLab.CA.Axioms
{
    public interface ISelectAxiom
    {
        INewAxiom NewAxiom { get; }
        IComplexSelector Selector { get; }
    }
}