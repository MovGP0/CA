using System.Linq.Expressions;
using AIRLab.CA.ExpressionConverters;
using AIRLab.CA.Nodes;
using NUnit.Framework;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestFixture]
    public class Tests
    {
        protected delegate double Del();
        protected delegate double Del1(double p);
        protected delegate double Del2(double p1, double p2);

        public static INode SimplifyBinaryExpression(Expression e)
        {
            return ComputerAlgebra.Simplify(Expressions2Tree.Parse(e));
        }

        public static INode SimplifyLogicTree(INode root)
        {
            return ComputerAlgebra.Simplify(root);
        }
    }
}
