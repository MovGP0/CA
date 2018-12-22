using System.Collections.Generic;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Logic;

namespace AIRLab.CA.Algebra
{
    public class LogicAxioms : SelectClauseWriter
    {
        public static IEnumerable<IAxiom> Get()
        {
            yield return Axiom
                .New("&&0", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<And, Constant<bool>, INode>(z => !z.B.Value)
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("||1", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<Or, Constant<bool>, INode>(z => z.B.Value)
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("&&1", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<And, Constant<bool>, INode>(z => z.B.Value)
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("||0", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<Or, Constant<bool>, INode>(z => !z.B.Value)
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("!!", StdTags.Deductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[B[C]])
                .Where<Not, Not, INode>()
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("x V x", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB, ChildC])
                .Where<Or, INode, INode>(z => UnificationService.IsSame(z.B, z.C, true))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("!x V x", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB[ChildC], ChildD])
                .Where<Or, Not, INode, INode>(z => UnificationService.IsSame(z.C, z.D, true))
                .Mod(z => z.A.Replace(new Constant<bool>(true)));
        }
    }
}