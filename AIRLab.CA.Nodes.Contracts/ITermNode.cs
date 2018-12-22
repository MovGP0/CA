namespace AIRLab.CA.Nodes
{
    /// <summary>
    /// Implementation of Terms in first-order logic.
    /// </summary>
    public interface ITermNode : INode<bool>
    {
        /// <summary>
        /// The name of the term.
        /// </summary>
        string Name { get; }
    }
}
