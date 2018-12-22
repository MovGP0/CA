// ComputerAlgebra Library
//
// Copyright � Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using AIRLab.CA.Nodes;
using AIRLab.CA.Regression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AIRLab.CA.Tests
{
    [TestClass]
    public class RegressionTests
    {
        private const double NoiseLevel = 0.01;
        private static readonly Random RandomNumberGenerator = new Random();

        [TestMethod]
        public void TwoVarsTreeOps()
        {
            var service = new SampleGenerator.SampleGenerator(2, 3, 0.001);
            var formula = service.GetFormula();
            var noiseFormula = formula.Clone<INode>();
            NoisyConstants(noiseFormula);
            var algorithm = new RegressionAlgorithm(noiseFormula, service.InSamples, service.ExactResult);
            algorithm.Run();
            Assert.AreNotEqual(null, algorithm.GetResult());
        }

        private static void NoisyConstants(INode node)
        {
            if (node.HasChildren())
            {
                foreach (var child in node.Children)
                {
                    NoisyConstants(child);
                }
                return;
            }

            if (!(node is Constant))
                return;

            var oldValue = ((Constant<double>)node).Value;
            var childIndex = node.Parent.IndexOfChild(node);
            INode newConst = new Constant<double>(oldValue + Math.Pow((-1), RandomNumberGenerator.Next(3)) * RandomNumberGenerator.Next((int)(oldValue / 2), (int)(oldValue * 2)) * NoiseLevel);
            node.Parent.Children[childIndex] = newConst;
        }
    }
}
