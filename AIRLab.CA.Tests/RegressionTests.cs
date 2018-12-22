using System;
using AIRLab.CA.Nodes;
using AIRLab.CA.Regression;
using NUnit.Framework;

namespace AIRLab.CA.Tests
{
    [TestFixture]
    public class RegressionTests
    {
        private const double NoiseLevel = 0.01;
        private static readonly Random RandomNumberGenerator = new Random();

        [Test]
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
