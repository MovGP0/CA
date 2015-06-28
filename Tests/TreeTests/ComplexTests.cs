﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AIRLab.CA.Tests.TreeTests
{
    [TestClass]
    public class ComplexTests : Tests
    {        
        // ((x+y)+0)*1 => x+y
        [TestMethod]
        public void FirstLevel()
        {
            Expression<Del2> expression = (x, y) => ((x + y) + 0) * 1;
            Assert.AreEqual(
                 new Addition<double>(VariableNode.Make<double>(0, "x"), VariableNode.Make<double>(1, "y")).ToString(),
                 SimplifyBinaryExpression(expression.Body).ToString());
        }

        // ((((x^1)-0)-((3+2)+(0/1)))∙y) => (x-5)*y
        [TestMethod]
        public void SecondLevel()
        {
            Expression<Del2> expression = (x, y) => (((Math.Pow(x, 1)-0)-((3+2)+(0/1)))*y);
            Assert.AreEqual(
                 new ScalarProduct<double>(
                     new Minus<double>(
                         VariableNode.Make<double>(0, "x"), new Constant<double>(5.0)), 
                     VariableNode.Make<double>(1, "y")).ToString(),
                 SimplifyBinaryExpression(expression.Body).ToString());
        }
    }
}
