using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Comparison;
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
            Assert.AreEqual(bool.FalseString, SimplifyLogicTree(root).ToString());
        }

        //&&1
        [Test]
        public void AndOne()
        {
            INode root = new And(VariableNode.Make<bool>(0, "x"), new Constant<bool>(true));
            Assert.AreEqual(VariableNode.Make<bool>(0, "x").ToString(), SimplifyLogicTree(root).ToString());
        }

        //||0
        [Test]
        public void OrZero()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), new Constant<bool>(false));
            Assert.AreEqual(VariableNode.Make<bool>(0, "x").ToString(), SimplifyLogicTree(root).ToString());
        }

        //||1
        [Test]
        public void OrOne()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), new Constant<bool>(true));
            Assert.AreEqual(bool.TrueString, SimplifyLogicTree(root).ToString());
        }

        //!!
        [Test]
        public void DoubleNot()
        {
            INode root = new Not(new Not(VariableNode.Make<bool>(0, "x")));
            Assert.AreEqual(VariableNode.Make<bool>(0, "x").ToString(), SimplifyLogicTree(root).ToString());
        }

        //x V x
        [Test]
        public void XOrX()
        {
            INode root = new Or(VariableNode.Make<bool>(0, "x"), VariableNode.Make<bool>(0, "x"));
            Assert.AreEqual(VariableNode.Make<bool>(0, "x").ToString(), SimplifyLogicTree(root).ToString());
        }

        //!x V x
        [Test]
        public void XOrNotX()
        {
            INode root = new Or(new Not(VariableNode.Make<bool>(0, "x")), VariableNode.Make<bool>(0, "x"));
            Assert.AreEqual(bool.TrueString, SimplifyLogicTree(root).ToString());
        }

        [Test]
        public void XEqualsX()
        {
            INode root = new Equal(VariableNode.Make<bool>(0, "x"), VariableNode.Make<bool>(0, "x"));
            Assert.AreEqual(bool.TrueString, SimplifyLogicTree(root).ToString());
        }

        [Test]
        public void XEqualsY()
        {
            INode root = new Equal(VariableNode.Make<bool>(0, "x"), VariableNode.Make<bool>(0, "y"));
            Assert.AreEqual("x = y", SimplifyLogicTree(root).ToString());
        }

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        public void BoolEqualsBool(bool left, bool right, bool expected)
        {
            INode root = new Equal(new Constant<bool>(left), new Constant<bool>(right));
            Assert.AreEqual(expected.ToString(), SimplifyLogicTree(root).ToString());
        }
        #endregion
    }

}
