using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestFixture]
    public class SimpleAlgebraicTests : Tests
    {
        // +0
        [Test]
        public void PlusZero()
        {
            Expression<Del1> expression = x => x + 0;
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
        }

        // -0
        [Test]
        public void MinusZero()
        {
            Expression<Del1> expression = x => x - 0;
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
        }

        // 0-
        [Test]
        public void ZeroMinus()
        {
            Expression<Del1> expression = x => 0 - x;
            Assert.AreEqual(
                "-(x)",
                SimplifyBinaryExpression(expression).ToString());
        }

        // *0
        [Test]
        public void ProductZero()
        {
            Expression<Del1> expression = x => x * 0;
            Assert.AreEqual(
                "0",
                SimplifyBinaryExpression(expression).ToString());
        }

        // 0/
        [Test]
        public void ZeroDivide()
        {
            Expression<Del1> expression = x => 0 / x;
            Assert.AreEqual(
                "0",
                SimplifyBinaryExpression(expression).ToString());
        }

        // ^0
        [Test]
        public void PowZero()
        {
            Expression<Del1> expression = x => Math.Pow(x, 0);
            Assert.AreEqual(
                "1",
                SimplifyBinaryExpression(expression).ToString());
        }

        // 0^
        [Test]
        public void ZeroPow()
        {
            Expression expression = Expression.Power(Expression.Constant(0.0),
                Expression.Parameter(typeof(double), "x"));
            Assert.AreEqual(
                "0",
                SimplifyBinaryExpression(expression).ToString());
        }

        // *1
        [Test]
        public void ProductOne()
        {
            Expression<Del1> expression = x => x * 1;
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
        }

        // /1
        [Test]
        public void DivideOne()
        {
            Expression<Del1> expression = x => x / 1;
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
        }

        // ^1
        [Test]
        public void PowOne()
        {
            Expression<Del1> expression = x => Math.Pow(x, 1);
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
        }

        // (-0)
        [Test]
        public void NegateZero()
        {
            Expression<Del> expression = () => -0;
            Assert.AreEqual(
                "0",
                SimplifyBinaryExpression(expression).ToString());
        }

        // C+C
        [Test]
        public void ConstPlus()
        {
            Expression<Del> expression = () => 2 + 1;
            Assert.AreEqual(
                "3",
                SimplifyBinaryExpression(expression).ToString());
        }

        // C-C
        [Test]
        public void ConstMinus()
        {
            Expression<Del> expression = () => 2 - 1;
            Assert.AreEqual(
                "1",
                SimplifyBinaryExpression(expression).ToString());
        }

        // C*C
        [Test]
        public void ConstProduct()
        {
            Expression<Del> expression = () => 2 * 2;
            Assert.AreEqual(
                "4",
                SimplifyBinaryExpression(expression).ToString());
        }

        // C/C
        [Test]
        public void ConstDivide()
        {
            Expression<Del> expression = () => 4 / 2;
            Assert.AreEqual(
                "2",
                SimplifyBinaryExpression(expression).ToString());
        }

        // C^C
        [Test]
        public void ConstPow()
        {
            Expression<Del> expression = () => Math.Pow(2, 2);
            Assert.AreEqual(
                "4",
                SimplifyBinaryExpression(expression).ToString());
        }

        // (x+C)+C
        [Test]
        public void XPlusConstPlusConst()
        {
            Expression<Del1> expression = (x) => (x + 5) + 5;
            Assert.AreEqual(
                "(x+10)",
                SimplifyBinaryExpression(expression).ToString());
            expression = (x) => 3 + (x + 1);
            Assert.AreEqual(
                "(x+4)",
                SimplifyBinaryExpression(expression).ToString());
        }

        // (x-C)+C
        [Test]
        public void XMinusConstPlusConst()
        {
            Expression<Del1> expression = (x) => (x - 5) + 5;
            Assert.AreEqual(
                "x",
                SimplifyBinaryExpression(expression).ToString());
            expression = (x) => 3 + (x - 1);
            Assert.AreEqual(
                "(x+2)",
                SimplifyBinaryExpression(expression).ToString());
            expression = (x) => 3 + (1 - x);
            Assert.AreNotEqual(
                "(x+2)",
                SimplifyBinaryExpression(expression).ToString());
        }
    }
}