namespace AIRLab.CA.Axioms
{
    public interface IWhereOutput
    {
        ISelectOutput SelectResult { get; set; }
        IModInput MakeSafe();
    }
}