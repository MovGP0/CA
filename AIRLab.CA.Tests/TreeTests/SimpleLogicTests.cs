using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Logic;
using NUnit.Framework;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestFixture]
    public class SimpleLogicTests : Tests
    {
        #region Logic
        //&&0
        [Test]
        public void AndZero()
        {
            INode root = new And(VariableNode.Make<bool>(0, "x"), new Constant<bool>(false));
            Assert.AreEqual(
                bool.FalseString,
                SimplifyLogicTree(root).ToString());
        }
        //&&1
        [Test]
        public void AndOne()
        {
            INode root = new And(VariableNode.Make<bool>(0, "x"), new Constant<bool>(true));
            Assert.AreEqual(
                VariableNode.Make<bool>(0, "x").ToString(),
                SimplifyLogicTree(root).ToString());
        }
        //||0
        [Test]
        public void OrZero()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), new Constant<bool>(false));
            Assert.AreEqual(
                VariableNode.Make<bool>(0, "x").ToString(),
                SimplifyLogicTree(root).ToString());
        }
        //||1
        [Test]
        public void OrOne()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), new Constant<bool>(true));
            Assert.AreEqual(
                bool.TrueString,
                SimplifyLogicTree(root).ToString());
        }
        //!!
        [Test]
        public void DoubleNot()
        {
            INode root = new Not(new Not(VariableNode.Make<bool>(0, "x")));
            Assert.AreEqual(
                VariableNode.Make<bool>(0, "x").ToString(),
                SimplifyLogicTree(root).ToString());
        }

        //x V x
        [Test]
        public void XOrX()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), VariableNode.Make<bool>(0, "x"));
            Assert.AreEqual(
                VariableNode.Make<bool>(0, "x").ToString(),
                SimplifyLogicTree(root).ToString());
        }

        //!x V x
        [Test]
        public void XOrNotX()
        {
            INode root = new Or(new Not(VariableNode.Make<bool>(0, "x")), VariableNode.Make<bool>(0, "x"));
            Assert.AreEqual(
                new Constant<bool>(true).ToString(),
                SimplifyLogicTree(root).ToString());
        }

        #endregion
    }

}
