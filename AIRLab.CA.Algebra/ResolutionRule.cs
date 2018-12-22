using System.Linq;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Logic;

namespace AIRLab.CA.Algebra
{
    public class ResolutionAxiom : SelectClauseWriter
    {
        public static IAxiom Get()
        {
            return Axiom
                .New("Resolve", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection)
                .Select(A[ChildB], C[ChildD])
                .Where<MultipleOr, SkolemPredicateNode, MultipleOr, SkolemPredicateNode>(z =>
                    UnificationService.CanUnificate(z.B, z.D) && (z.B.IsNegate || z.D.IsNegate))
                .Mod(Modificator);
        }

        /// <summary>
        /// Using resolution rule: A V B, C V !B |- A V C. 
        /// </summary>
        /// <param name="z"></param>
        private static void Modificator(ITypizedDecorArray<MultipleOr, SkolemPredicateNode, MultipleOr, SkolemPredicateNode> z)
        {
            var rules = UnificationService.GetUnificationAxioms(z.B.Node, z.D.Node);
            UnificationService.Unificate(z.A.Node, rules);
            UnificationService.Unificate(z.C.Node, rules);
            var aChildren = z.A.Node.Children.ToList();
            var cChildren = z.C.Node.Children.ToList();
            aChildren.Remove(z.B.Node);
            cChildren.Remove(z.D.Node);
            z.A.Replace(new MultipleOr(aChildren.ToArray()));
            z.C.Replace(new MultipleOr(cChildren.ToArray()));
        }
    }
}
