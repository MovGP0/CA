﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Collections.Generic;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;

namespace AIRLab.CA.Algebra
{
    public class AlgebraicAxioms : SelectClauseWriter
    {
        public static IEnumerable<IAxiom> Get()
        {
            yield return Axiom
                .New("*0", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<ScalarProduct<double>, Constant<double>, INode>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("*1", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<ScalarProduct<double>, Constant<double>, INode>(z => z.B.Value.Equals(1d))
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("+0", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[ChildB, ChildC])
                .Where<Addition<double>, Constant<double>, INode>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.C.Node));

            yield return Axiom
                .New("-0", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Minus<double>, INode, Constant<double>>(z => z.C.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("0-", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Minus<double>, Constant<double>, INode>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(new Negate<double>(z.C.Node)));

            yield return Axiom
                .New("/1", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Divide<double>, INode, Constant<double>>(z => z.C.Value.Equals(1d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("0/", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Divide<double>, Constant<double>, INode>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("0^", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Pow<double>, Constant<double>, INode>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("^1", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Pow<double>, INode, Constant<double>>(z => z.C.Value.Equals(1d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("^0", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Pow<double>, INode, Constant<double>>(z => z.C.Value.Equals(0d))
                .Mod(z => z.A.Replace(new Constant<double>(1)));

            yield return Axiom
                .New("(-0)", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B])
                .Where<Negate<double>, Constant<double>>(z => z.B.Value.Equals(0d))
                .Mod(z => z.A.Replace(z.B.Node));

            yield return Axiom
                .New("C+C", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Addition<double>, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Constant<double>(z.B.Node.Value + z.C.Node.Value)));

            yield return Axiom
                .New("C*C", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<ScalarProduct<double>, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Constant<double>(z.B.Node.Value * z.C.Node.Value)));

            yield return Axiom
                .New("C-C", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Minus<double>, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Constant<double>(z.B.Node.Value - z.C.Node.Value)));

            yield return Axiom
                .New("C^C", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Pow<double>, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Constant<double>(Math.Pow(z.B.Node.Value, z.C.Node.Value))));

            yield return Axiom
                .New("C/C", StdTags.SafeResection, StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[B, C])
                .Where<Divide<double>, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Constant<double>(z.B.Node.Value / z.C.Node.Value)));

            yield return Axiom
                .New("(x+C)+C", StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[ChildB[ChildC, ChildD], ChildE])
                .Where<Addition, Addition, INode, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Addition<double>(z.C.Node, new Constant<double>(z.D.Node.Value + z.E.Node.Value))));

            yield return Axiom
                .New("(x-C)+C", StdTags.Algebraic, StdTags.Simplification)
                .Select(AnyA[ChildB[C, D], ChildE])
                .Where<Addition, Minus, INode, Constant<double>, Constant<double>>()
                .Mod(z => z.A.Replace(new Addition<double>(z.C.Node, new Constant<double>(z.E.Node.Value - z.D.Node.Value))));
        }
    }
}
