﻿using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public static class SelectWhereAxiomExtensions
    {
        public static Axiom Mod<T0>(this ISelectWhereAxiom<T0> axiom, Action<ITypizedDecorArray<T0>> replace)
            where T0 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0>)z));
        }

        public static Axiom Mod<T0, T1>(this ISelectWhereAxiom<T0, T1> axiom, Action<ITypizedDecorArray<T0, T1>> replace)
            where T0 : INode 
            where T1 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1>)z));
        }

        public static Axiom Mod<T0, T1, T2>(this ISelectWhereAxiom<T0, T1, T2> axiom, Action<ITypizedDecorArray<T0, T1, T2>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3>(this ISelectWhereAxiom<T0, T1, T2, T3> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4>(this ISelectWhereAxiom<T0, T1, T2, T3, T4> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7, T8>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
            where T8 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
            where T8 : INode 
            where T9 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
            where T8 : INode 
            where T9 : INode 
            where T10 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
            where T8 : INode 
            where T9 : INode 
            where T10 : INode 
            where T11 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)z));
        }

        public static Axiom Mod<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> axiom, Action<ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> replace)
            where T0 : INode 
            where T1 : INode 
            where T2 : INode 
            where T3 : INode 
            where T4 : INode 
            where T5 : INode 
            where T6 : INode 
            where T7 : INode 
            where T8 : INode 
            where T9 : INode 
            where T10 : INode 
            where T11 : INode 
            where T12 : INode 
        {
            return new Axiom(axiom.SelectAxiom.NewAxiom.Name, axiom.SelectAxiom.NewAxiom.Tags, axiom.SelectAxiom.Selector, z => axiom.Invoke(z), z => replace((ITypizedDecorArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)z));
        }
    }
}
