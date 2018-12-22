namespace AIRLab.CA.Nodes
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// An algebraic node.
    /// </summary>
    public interface INode : ICloneable
    {
        /// <summary>
        /// The child nodes of the expression tree.
        /// </summary>
        /// <value>
        /// A collection of children.
        /// </value>
        IChildrenCollection Children { get; }

        /// <summary>
        /// The parent node in the expression tree.
        /// </summary>
        /// <value>
        /// A parent <see cref="INode"/>.
        /// </value>
        INode Parent { get; set; }

        /// <summary>
        /// The <see cref="Type"/> of the node.
        /// </summary>
        /// <value>
        /// The <see cref="Type"/> of the node.
        /// </value>
        Type Type { get; }

        /// <summary>
        /// Creates an LINQ expression.
        /// </summary>
        /// <returns>
        /// The LINQ expression.
        /// </returns>
        Expression BuildExpression();

        /// <summary>
        /// Makes this element to be the root of the expression tree.
        /// </summary>
        void MakeRoot();
    }
}
