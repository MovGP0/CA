using System.Linq;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestClass]
    public class AxiomsTest : SelectClauseWriter
    {
        readonly INode _root1 =
            new TestOp(
                new TestOp(
                    new TestOp(
                        new TestOp())),
                new TestOp(
                    new TestOp(
                        new TestOp(),
                        new TestOp()),
                    new TestOp(
                        new TestOp(),
                        new TestOp(),
                        new TestOp())));

        readonly INode _root2 =
            new TestOp(
                new TestOp(
                    new TestOp(),
                    new TestOp()),
                new TestOp(
                    new TestOp()));

        [TestMethod]
        public void Test()
        {
            Test(12, AnyA, _root1);
            Test(26, AnyA[AnyB], _root1);
            Test(162, AnyA[AnyB, AnyC], _root1);
            Test(21, AnyA[AnyB[AnyC]], _root1);
            Test(11, AnyA[ChildB], _root1);
            Test(12, AnyA[ChildB, ChildC], _root1);
            Test(2, AnyA[B], _root1);
            Test(3, AnyA[B, C], _root1);

            Test(72, AnyA, AnyB, _root1, _root2);
            Test(55, AnyA[ChildB], AnyC[ChildD], _root1, _root2);
            Test(1, A, B, _root1, _root2);
            Test(1, A, _root1);
        }

        static void Test(int expectedCount, params object[] q)
        {
            var num = q.Length / 2;
            var clauses = q.Take(num).Select(z => (SelectClauseNode)z).ToArray();
            var roots = q.Skip(num).Select(z => (INode)z).ToArray();
            var selector = new ComplexSelector(clauses);
            Assert.IsTrue(selector.Select(roots).Count() == expectedCount);
        }
    }
}