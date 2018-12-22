using System.Collections.Generic;
using System.Linq;
using AIRLab.CA.Algebra;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Regression;

namespace AIRLab.CA
{
    public static class AxiomsLibrary
    {
        /// <summary>
        /// Apply each rule from collection to passed node, while it possible
        /// </summary>
        /// <param name="node"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static INode ApplyAxioms(INode node, IAxiom[] rules)
        {
            var current = node;
            string firstRep;

            do
            {
                firstRep = current.ToString();
                foreach (var r in rules)
                {
                    var instances = r.SelectWhere(current);
                    var whereOutputs = instances as WhereOutput[] ?? instances.ToArray();
                    if (instances == null || !whereOutputs.Any())
                        continue;

                    foreach (var roots in whereOutputs.Select(r.Apply).Where(roots => roots != null && roots.Any() && roots[0] != null))
                    {
                        current = roots[0];
                        break;
                    }
                }
            }
            while (firstRep != current.ToString());

            return current;
        }

        /// <summary>
        /// Get a list of algebraic and logic simplification rules
        /// </summary>
        /// <returns></returns>
        public static IAxiom[] GetSimplificationAxioms()
        {
            var simplificationAxioms = AlgebraicAxioms.Get()
                                 .Where(r => r.Tags.Contains(StdTags.Simplification))
                                 .ToList();
            simplificationAxioms.AddRange(LogicAxioms.Get().Where(r => r.Tags.Contains(StdTags.Simplification)));
            return simplificationAxioms.ToArray();
        }

        /// <summary>
        /// Get a list of simple differentiation rules
        /// </summary>
        /// <returns></returns>
        public static IList<IAxiom> GetDifferentiationAxioms()
        {
            return DifferentiationAxioms.Get().ToList();
        }

        /// <summary>
        /// You can run regression algorithm by applying these rules 
        /// </summary>
        /// <param name="inSample">Experimental data</param>
        /// <param name="exactResult">Experimental result</param>
        /// <returns></returns>
        public static IList<IAxiom> GetRegeressionAxiom(IList<double[]> inSample, IList<double> exactResult)
        {
            return RegressionAxioms.Get(inSample, exactResult).ToList();
        }

        /// <summary>
        /// Axiom from resolution technique, used for deciding the satisfiability of a propositional formula, in first-order-logic 
        /// </summary>
        /// <seealso cref="ComputerAlgebra.Resolve"/>
        /// <returns></returns>
        public static IAxiom GetResolutionAxiom()
        {
            return ResolutionAxiom.Get();
        }
    }
}
