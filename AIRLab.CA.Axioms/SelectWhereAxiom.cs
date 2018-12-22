using System;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public class SelectWhereAxiom : ISelectWhereAxiom
    {
        public ISelectAxiom SelectAxiom { get; private set; }
        public SelectWhereAxiom(ISelectAxiom selectAxiom)
        {
            SelectAxiom = selectAxiom;
        }
    }

    public class SelectWhereAxiom<T0> : SelectWhereAxiom, ISelectWhereAxiom<T0>
        where T0 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1>
        where T0 : INode 
        where T1 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
        where T3 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
        where T3 : INode 
        where T4 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
        where T3 : INode 
        where T4 : INode 
        where T5 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
        where T3 : INode 
        where T4 : INode 
        where T5 : INode 
        where T6 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7>
        where T0 : INode 
        where T1 : INode 
        where T2 : INode 
        where T3 : INode 
        where T4 : INode 
        where T5 : INode 
        where T6 : INode 
        where T7 : INode 
    {
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8>
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
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
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
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
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
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
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
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
    public class SelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : SelectWhereAxiom, ISelectWhereAxiom<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
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
        public Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> Invoke { get; private set; }

        public SelectWhereAxiom(ISelectAxiom selectAxiom, Func<ISelectOutput, ITypizedNodeArray<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> where) : base(selectAxiom)
        {
            Invoke = where;
        }
    }
}
