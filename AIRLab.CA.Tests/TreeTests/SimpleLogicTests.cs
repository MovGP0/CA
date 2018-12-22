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
        [Test]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public void Not(bool value, bool expected)
        {
            INode root = new Not(new Constant<bool>(value));
            Assert.AreEqual(expected.ToString(), SimplifyLogicTree(root).ToString());
        }

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void And(bool left, bool right, bool expected)
        {
            INode root = new And(new Constant<bool>(left), new Constant<bool>(right));
            Assert.AreEqual(expected.ToString(), SimplifyLogicTree(root).ToString());
        }

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(false, false, false)]
        public void Or(bool left, bool right, bool expected)
        {
            INode root = new Or(new Constant<bool>(left), new Constant<bool>(right));
            Assert.AreEqual(expected.ToString(), SimplifyLogicTree(root).ToString());
        }

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

        // ¬(A Λ B) = (¬A) ∨ (¬B) ⇒ true
        [Test]
        public void NotAAndB()
        {
            var A = VariableNode.Make<bool>(0, "A");
            var B = VariableNode.Make<bool>(0, "B");
            var A1 = VariableNode.Make<bool>(0, "A");
            var B1 = VariableNode.Make<bool>(0, "B");

            INode left = new Not(new And(A, B));
            INode right = new Or(new Not(A1), new Not(B1));
            INode root = new Equal(left, right);
            Assert.AreEqual(true.ToString(), SimplifyLogicTree(root).ToString());
        }

        // ¬(A ∨ B) = (¬A) Λ (¬B) ⇒ true
        [Test]
        public void NotAOrB()
        {
            var A = VariableNode.Make<bool>(0, "A");
            var B = VariableNode.Make<bool>(0, "B");
            var A1 = VariableNode.Make<bool>(0, "A");
            var B1 = VariableNode.Make<bool>(0, "B");

            INode left = new Not(new Or(A, B));
            INode right = new And(new Not(A1), new Not(B1));
            INode root = new Equal(left, right);
            Assert.AreEqual(true.ToString(), SimplifyLogicTree(root).ToString());
        }
        #endregion
    }
}
