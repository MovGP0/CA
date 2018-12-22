using System.Collections.Generic;

namespace AIRLab.CA.Axioms
{
    public class NewAxiom : INewAxiom
    {
        public string Name { get; }
        public IEnumerable<string> Tags { get; }

        public NewAxiom(string name, IEnumerable<string> tags)
        {
            Name = name;
            Tags = tags;
        }
    }
}
