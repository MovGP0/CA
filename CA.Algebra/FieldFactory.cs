﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System.Collections.Generic;
using AIRLab.CA.Axioms;
using AIRLab.CA.Nodes;
using AIRLab.CA.Operators.Arithmetic;

namespace AIRLab.CA.Algebra
{
    public class FieldFactory<TField> : SelectClauseWriter
    {
        public IEnumerable<IAxiom> Create(Constant<TField> additiveIdentity, Constant<TField> multiplicativeIdentity)
        {
            var additiveIdentities = new List<Constant<TField>> { additiveIdentity };
            var multiplicativeIdentities = new List<Constant<TField>> { multiplicativeIdentity };
            return Create(additiveIdentities, multiplicativeIdentities);
        }

        public IEnumerable<IAxiom> Create(IEnumerable<Constant<TField>> additiveIdentities, IEnumerable<Constant<TField>> multiplicativeIdentities)
        {
            // a+(d+e) => (a+d)+e
            yield return Axiom
                .New("Associativity of addition")
                .Select(AnyA[ChildB, ChildC[ChildD, ChildE]])
                .Where<Addition<TField>, INode<TField>, Addition<TField>, INode<TField>, INode<TField>>()
                .Mod(z => z.A.Replace(new Addition<TField>(new Addition<TField>(z.B.Node, z.D.Node), z.E.Node)));

            // a•(d•e) => (a•d)•e
            yield return Axiom
                .New("Associativity of multiplication")
                .Select(AnyA[ChildB, ChildC[ChildD, ChildA]])
                .Where<ScalarProduct<TField>, INode<TField>, ScalarProduct<TField>, INode<TField>, INode<TField>>()
                .Mod(z => z.A.Replace(new ScalarProduct<TField>(new ScalarProduct<TField>(z.B.Node, z.D.Node), z.E.Node)));

            // b+c => c+b
            yield return Axiom
                .New("Commutativity of addition", StdTags.Algebraic)
                .Select(AnyA[ChildB, ChildC])
                .Where<Addition<TField>, INode<TField>, INode<TField>>()
                .Mod(z =>
                {
                    var temp = z.B.Node;
                    z.B.Replace(z.C.Node);
                    z.C.Replace(temp);
                });

            // b•c => c•b
            yield return Axiom
                .New("Commutativity of multiplication", StdTags.Algebraic)
                .Select(AnyA[ChildB, ChildC])
                .Where<ScalarProduct<TField>, INode<TField>, INode<TField>>()
                .Mod(z =>
                {
                    var temp = z.B.Node;
                    z.B.Replace(z.C.Node);
                    z.C.Replace(temp);
                });

            // b+0 => b
            foreach (var additiveIdentity in additiveIdentities)
            {
                var identity = additiveIdentity;
                yield return Axiom
                    .New("Existence of additive identity element", StdTags.Algebraic)
                    .Select(AnyA[ChildB, ChildC])
                    .Where<Addition<TField>, INode<TField>, Constant<TField>>(z => z.C.Equals(identity))
                    .Mod(z => z.A.Replace(z.B.Node));
            }

            // b•1 => b
            foreach (var multiplicativeIdentity in multiplicativeIdentities)
            {
                var identity = multiplicativeIdentity;
                yield return Axiom
                    .New("Existence of multiplicative identity element", StdTags.Algebraic)
                    .Select(AnyA[ChildB, ChildC])
                    .Where<ScalarProduct<TField>, INode<TField>, Constant<TField>>(z => z.C.Equals(identity))
                    .Mod(z => z.A.Replace(z.B.Node));
            }


        }
    }
}
