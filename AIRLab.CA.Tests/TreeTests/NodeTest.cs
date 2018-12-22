﻿using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;
using AIRLab.CA.Operators.Logic;
using NUnit.Framework;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestFixture]
    public class NodeTest
    {
        [Test]
        public void TreeHasCorrectStringForm()
        {
            var tree = new ScalarProduct<int>(VariableNode.Make<int>(0, "x"),
                                                   new Addition<int>(VariableNode.Make<int>(1, "y"),
                                                                            new Constant<int>(3)));
            Assert.AreEqual("(x∙(y+3))", tree.ToString());
            var tree2 = new MultipleOr(new PredicateNode("P", VariableNode.Make<int>(0, "x")),
                                                new PredicateNode("Q", VariableNode.Make<int>(1, "y"), VariableNode.Make<int>(2, "z")),
                                                new PredicateNode("H", new FunctionNode("f", VariableNode.Make<int>(0, "x")), new FunctionNode("c")));
            Assert.AreEqual("P(x) ∨ Q(y,z) ∨ H(f(x),c)", tree2.ToString());
        }

        [Test]
        public void NodesKeepProperInfo()
        {
            var constant = new Constant<int>(1);
            Assert.AreEqual(constant.Value, 1);
            Assert.AreEqual(constant.Type, typeof(int));
            Assert.AreEqual(constant.Children.Length, 0);

            var variable = VariableNode.Make<int>(0, "x");
            Assert.AreEqual(variable.Index, 0);
            Assert.AreEqual(variable.Type, typeof(int));
            Assert.AreEqual(variable.Children.Length, 0);

            var op = new Addition<int>(constant, variable);
            Assert.AreEqual(op.Children.Length, 2);
            Assert.AreEqual(op.Type, typeof(int));
            Assert.AreEqual(op.Parent, null);
            Assert.AreEqual(variable.Parent, op);
            Assert.AreEqual(constant.Parent, op);
        }
    }
}
