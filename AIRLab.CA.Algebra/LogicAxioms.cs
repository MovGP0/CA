﻿using System.Collections.Generic;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Comparison;
using AIRLab.CA.Operators.Logic;

namespace AIRLab.CA.Algebra
{
    public sealed class LogicAxioms : SelectClauseWriter
    {
        public static IEnumerable<IAxiom> Get()
        {
            yield return Axiom
                .New("¬true ⇒ false", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[B])
                .Where<Not, Constant<bool>>(z => z.B.Value)
                .Mod(z => z.A.Replace(new Constant<bool>(false)));

            yield return Axiom
                .New("¬false ⇒ true", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[B])
                .Where<Not, Constant<bool>>(z => !z.B.Value)
                .Mod(z => z.A.Replace(new Constant<bool>(true)));

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
                .New("¬¬x = x", StdTags.Deductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(AnyA[B[C]])
                .Where<Not, Not, INode>()
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("x ∨ x = x", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB, ChildC])
                .Where<Or, INode, INode>(z => UnificationService.IsSame(z.B, z.C, true))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("!x V x", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB[ChildC], ChildD])
                .Where<Or, Not, INode, INode>(z => UnificationService.IsSame(z.C, z.D, true))
                .Mod(z => z.A.Replace(new Constant<bool>(true)));

            yield return Axiom
                .New("x = x ⇒ true", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB, ChildC])
                .Where<Equal, INode, INode>(z => UnificationService.IsSame(z.B, z.C, true))
                .Mod(z => z.A.Replace(new Constant<bool>(true)));

            yield return Axiom
                .New("true = true ⇒ true", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB, ChildC])
                .Where<Equal, Constant<bool>, Constant<bool>>(z => z.B.Value == z.C.Value)
                .Mod(z => z.A.Replace(new Constant<bool>(true)));

            yield return Axiom
                .New("true = false ⇒ false", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[ChildB, ChildC])
                .Where<Equal, Constant<bool>, Constant<bool>>(z => z.B.Value != z.C.Value)
                .Mod(z => z.A.Replace(new Constant<bool>(false)));

            yield return Axiom
                .New("¬(A Λ B) = (¬A) ∨ (¬B)", StdTags.Inductive, StdTags.Logic, StdTags.SafeResection, StdTags.Simplification)
                .Select(A[B[ChildC, ChildD]])
                .Where<Not, And, INode, INode>()
                .Mod(z => z.A.Replace(new Or(new Not(z.C.Node), new Not(z.D.Node))));
        }
    }
}