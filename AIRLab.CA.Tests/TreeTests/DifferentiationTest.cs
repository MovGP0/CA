// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Linq.Expressions;
using AIRLab.CA.ExpressionConverters;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;
using NUnit.Framework;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestFixture]
    public class DifferentiationTest : Tests
    {
        // (-x) dif x => -1
        [Test]
        public void DiffNegate()
        {
            Expression<Del1> expression = (x) => -x;
            Assert.AreEqual(
                "-1",
                ComputerAlgebra.Differentiate(expression.Body, variable: "x").ToString());
        }

        // (x+y) dif x => 1
        [Test]
        public void DiffPlus()
        {
            Expression<Del2> expression = (x, y) => x + y;
            Assert.AreEqual(
                "1",
                ComputerAlgebra.Differentiate(expression.Body, variable: "x").ToString());
        }
        // (x-y) dif x => 1
        [Test]
        public void DiffMinus()
        {
            Expression<Del2> expression = (x, y) => x - y;
            Assert.AreEqual(
                "1",
                ComputerAlgebra.Differentiate(expression.Body, variable: "x").ToString());
        }
        // (x*y) dif x => y
        [Test]
        public void DiffProduct()
        {
            Expression<Del2> expression = (x, y) => x * y;
            Assert.AreEqual(
                "y",
                ComputerAlgebra.Differentiate(expression.Body, variable: "x").ToString());
        }
        // (x/y) dif x => y/y^2
        [Test]
        public void DiffDivide()
        {
            Expression<Del2> expression = (x, y) => x / y;
            Assert.AreEqual(
                new Divide<double>(
                    VariableNode.Make<double>(1, "y"),
                    new Pow<double>(VariableNode.Make<double>(1, "y"), new Constant<double>(2))).ToString(),
                    ComputerAlgebra.Differentiate(Expressions2Tree.Parse(expression.Body), variable: "x").ToString());
        }

        // (x^C) dif x => C*x^(C-1)
        [Test]
        public void DiffPowConstant()
        {
            Expression<Del1> expression = (x) => Math.Pow(x, 3);
            Assert.AreEqual(
                new ScalarProduct<double>(new Constant<double>(3.0), new Pow<double>(VariableNode.Make<double>(0, "x"), new Constant<double>(2.0))).ToString(),
                ComputerAlgebra.Differentiate(Expressions2Tree.Parse(expression.Body), variable: "x").ToString());
        }

        // (Ln(x^2)) dif x => 2x/x^2
        [Test]
        public void DiffLn()
        {
            Expression<Del1> expression = (x) => Math.Log(Math.Pow(x, 2));
            Assert.AreEqual(
                new Divide<double>(new ScalarProduct<double>(new Constant<double>(2), VariableNode.Make<double>(0, "x")),
                    new Pow<double>(VariableNode.Make<double>(0, "x"), new Constant<double>(2))).ToString(),
                ComputerAlgebra.Differentiate(Expressions2Tree.Parse(expression.Body), variable: "x").ToString()
            );
        }

        // (x^y) dif x => ((x^y)*(y/y))
        [Test]
        public void DiffPowX()
        {
            Expression<Del2> expression = (x, y) => Math.Pow(x, y);
            Assert.AreEqual(
                new ScalarProduct<double>(
                    new Pow<double>(
                        VariableNode.Make<double>(0, "x"),
                        VariableNode.Make<double>(1, "y")),
                    new Divide<double>(
                        VariableNode.Make<double>(1, "y"),
                        VariableNode.Make<double>(0, "x"))).ToString(),
                ComputerAlgebra.Differentiate(Expressions2Tree.Parse(expression.Body), variable: "x").ToString());
        }
        // (x^y) dif y => ((x^y)*(Ln(y)))
        [Test]
        public void DiffPowY()
        {
            Expression<Del2> expression = (x, y) => Math.Pow(x, y);
            Assert.AreEqual(
                new ScalarProduct<double>(
                    new Pow<double>(
                        VariableNode.Make<double>(0, "x"),
                        VariableNode.Make<double>(1, "y")),
                    new Ln(VariableNode.Make<double>(0, "x")))
                    .ToString(),
                ComputerAlgebra.Differentiate(Expressions2Tree.Parse(expression.Body), variable: "y").ToString());
        }
    }
}
