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
