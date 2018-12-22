﻿using System.Collections.Generic;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;
using AIRLab.CA.Operators.Differentiation;

namespace AIRLab.CA.Algebra
{
    public class DifferentiationAxioms : SelectClauseWriter
    {
        public static IEnumerable<IAxiom> Get()
        {
            yield return Axiom
               .New("d(-U)/dx", StdTags.Differentiation, StdTags.Algebraic)
               .Select(AnyA[ChildB[ChildC], ChildD])
               .Where<Dif<double>, Negate<double>, INode, VariableNode>()
               .Mod(z => z.A.Replace(new Negate<double>(new Dif<double>(z.C.Node, z.D.Node))));

            yield return Axiom
                .New("d(U+V)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Dif<double>, Addition<double>, INode, INode, VariableNode>()
                .Mod(z => z.A.Replace(new Addition<double>(new Dif<double>(z.C.Node, z.E.Node), new Dif<double>(z.D.Node, (VariableNode)z.E.Node.Clone()))));

            yield return Axiom
                .New("d(U-V)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Dif<double>, Minus<double>, INode, INode, VariableNode>()
                .Mod(z => z.A.Replace(new Minus<double>(new Dif<double>(z.C.Node, z.E.Node), new Dif<double>(z.D.Node, (VariableNode)z.E.Node.Clone()))));

            yield return Axiom
                .New("d(U*V)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Dif<double>, ScalarProduct<double>, INode, INode, VariableNode>()
                .Mod(z => z.A.Replace(new Addition<double>(
                    new ScalarProduct<double>(new Dif<double>(z.C.Node, z.E.Node), z.D.Node),
                    new ScalarProduct<double>(new Dif<double>((INode)z.D.Node.Clone(), (VariableNode)z.E.Node.Clone()), (INode)z.C.Node.Clone()))));

            yield return Axiom
                .New("d(U/V)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Dif<double>, Divide<double>, INode, INode, VariableNode>()
                .Mod(z => z.A.Replace(new Divide<double>(
                        new Minus<double>(
                            new ScalarProduct<double>(
                                new Dif<double>(z.C.Node, z.E.Node), z.D.Node),
                            new ScalarProduct<double>(
                                new Dif<double>((INode)z.D.Node.Clone(), (VariableNode)z.E.Node.Clone()), (INode)z.C.Node.Clone())),
                        new Pow<double>((INode)z.D.Node.Clone(), new Constant<double>(2.0)))));

            yield return Axiom
                .New("d(U^c)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Dif<double>, Pow<double>, INode, Constant<double>, VariableNode>()
                .Mod(z => z.A.Replace(new ScalarProduct<double>(new ScalarProduct<double>(
                    new Constant<double>(z.D.Node.Value),
                    new Pow<double>(z.C.Node, new Constant<double>(z.D.Node.Value - 1))), new Dif<double>((INode)z.C.Node.Clone(), (VariableNode)z.E.Node.Clone()))));

            yield return Axiom
               .New("d(U^V)/dx", StdTags.Differentiation, StdTags.Algebraic)
               .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
               .Where<Dif<double>, Pow<double>, INode, INode, VariableNode>()
               .Mod(z => z.A.Replace(new ScalarProduct<double>(
                   new Pow<double>(z.C.Node, z.D.Node),
                   new Addition<double>(
                       new ScalarProduct<double>(new Dif<double>((INode)z.D.Node.Clone(), z.E.Node), new Ln((INode)z.C.Node.Clone())),
                       new Divide<double>(
                           new ScalarProduct<double>((INode)z.D.Node.Clone(), new Dif<double>((INode)z.C.Node.Clone(), (VariableNode)z.E.Node.Clone())),
                           (INode)z.C.Node.Clone())))));

            yield return Axiom
                .New("d(lnU)/dx", StdTags.Differentiation, StdTags.Algebraic)
                .Select(AnyA[ChildB[ChildC], ChildD])
                .Where<Dif<double>, Ln, INode, VariableNode>()
                .Mod(z => z.A.Replace(new Divide<double>(new Dif<double>(z.C.Node, z.D.Node), (INode)z.C.Node.Clone())));

            yield return Axiom
                .New("dx/dx", StdTags.Differentiation, StdTags.Deductive, StdTags.Algebraic)
                .Select(AnyA[ChildB, ChildC])
                .Where<Dif<double>, VariableNode, VariableNode>(z => z.B.Index == z.C.Index)
                .Mod(z => z.A.Replace(new Constant<double>(1.0)));

            yield return Axiom
                .New("dy/dx", StdTags.Differentiation, StdTags.Deductive, StdTags.Algebraic)
                .Select(AnyA[ChildB, ChildC])
                .Where<Dif<double>, VariableNode, VariableNode>(z => z.B.Index != z.C.Index)
                .Mod(z => z.A.Replace(new Constant<double>(0.0)));

            yield return Axiom
                .New("dc/dx", StdTags.Differentiation, StdTags.Deductive, StdTags.Algebraic)
                .Select(AnyA[ChildB, ChildC])
                .Where<Dif<double>, Constant<double>, VariableNode>()
                .Mod(z => z.A.Replace(new Constant<double>(0.0)));
        }
    }
}
