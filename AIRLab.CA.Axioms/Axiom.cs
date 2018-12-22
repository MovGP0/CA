using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    public class Axiom : IAxiom
    {
        private readonly IComplexSelector _selector;
        private readonly Func<ISelectOutput, IWhereOutput> _where;
        private readonly Action<IModInput> _apply;

        public string Name { get; }
        public IReadOnlyCollection<string> Tags { get; }

        public Axiom(string name, IEnumerable<string> tags, IComplexSelector selector,
            Func<ISelectOutput, IWhereOutput> where, Action<IModInput> apply)
        {
            _selector = selector;
            _where = where;
            _apply = apply;
            Name = name;
            Tags = new ReadOnlyCollection<string>(tags.ToArray());
        }

        public IEnumerable<ISelectOutput> Select(params INode[] roots)
        {
            return _selector.Select(roots);
        }

        public IEnumerable<IWhereOutput> SelectWhere(params INode[] roots)
        {
            return _selector.Select(roots)
                .Select(e => _where(e))
                .Where(res => res != null);
        }

        public INode[] Apply(IWhereOutput instance)
        {
            var safe = instance.MakeSafe();
            _apply(safe);
            return safe.Roots.Any(e => !e.TestRoot())
                ? null
                : safe.Roots;
        }

        public static INewAxiom New(string name, params string[] tags)
        {
            var axiomName = string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString() : name;
            return new NewAxiom(axiomName, tags);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}