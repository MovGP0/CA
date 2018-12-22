// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System.Collections.Generic;
using System.Linq;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    internal class LetterInstruction
    {
        /// <summary>
        /// Letter index for this instruction
        /// </summary>
        public int LetterIndex;

        /// <summary>
        /// Letter index for parent
        /// </summary>
        public int ParentIndex;

        /// <summary>
        /// True, if letter is root. Else false
        /// </summary>
        public bool IsRoot;

        /// <summary>
        /// Letter number in parent childs array
        /// </summary>
        public int ChildNumberInArray;

        /// <summary>
        /// Letter indexes of left brothers
        /// </summary>
        public int[] LeftBrotherIndexes;

        /// <summary>
        /// Recursion type of this letter
        /// </summary>
        public LetterRecursionType Recursive;

        /// <summary>
        /// Arity of the operation (not for leaves)
        /// </summary>
        public int? Arity;

        public IEnumerator<INode> Enumerator;
        public bool BreakThisBranch;

        public void Reset()
        {
            BreakThisBranch = false;
            Enumerator = null;
        }

        static IEnumerable<INode> CreateEnumerable(params INode[] data)
        {
            return data;
        }

        static IEnumerable<INode> FilterArity(int arity, IEnumerable<INode> bs)
        {
            return bs.Where(e => (arity == 0 && !e.HasChildren()) || (arity > 0 && e.HasChildren() && e.Children.Length == arity));
        }

        IEnumerable<INode> FilterBrothers(INode[] current, IEnumerable<INode> bs)
        {
            if (LeftBrotherIndexes != null && LeftBrotherIndexes.Length != 0)
            {
                return bs.Except(LeftBrotherIndexes.Select(z => current[z]));
            }
            return bs;
        }

        void CreateEnumerator(INode[] current, INode root)
        {
            var enumerable = CreateEnumerable();

            switch (Recursive)
            {
                case LetterRecursionType.No:
                    if (IsRoot)
                        enumerable = CreateEnumerable(root);
                    else
                    {
                        var n = current[ParentIndex];
                        if (n.Children != null || n.Children.Length > ChildNumberInArray)
                            enumerable = CreateEnumerable(n.Children[ChildNumberInArray]);
                    }
                    break;

                case LetterRecursionType.Subtree:
                    var rt = IsRoot ? root : current[ParentIndex];
                    var collection = rt.GetSubTree();
                    collection = IsRoot ? collection : collection.Skip(1);
                    collection = collection.ToArray();
                    enumerable = collection;
                    break;

                case LetterRecursionType.Children:
                    if (IsRoot)
                        enumerable = CreateEnumerable(root);
                    else if (current[ParentIndex].HasChildren())
                        enumerable = current[ParentIndex].Children;

                    break;

            }

            if (Arity != null) enumerable = FilterArity(Arity.Value, enumerable);
            if (Recursive != LetterRecursionType.No) enumerable = FilterBrothers(current, enumerable);
            Enumerator = enumerable.GetEnumerator();

        }


        public bool ApplyInstruction(INode[] current, INode root)
        {
            if (Enumerator == null) CreateEnumerator(current, root);
            var breackBranch = !Enumerator.MoveNext();
            if (!breackBranch)
                current[LetterIndex] = Enumerator.Current;
            return breackBranch;
        }
    }
}
