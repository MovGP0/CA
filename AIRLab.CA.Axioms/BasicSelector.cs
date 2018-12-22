using System;
using System.Collections.Generic;
using System.Linq;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Axioms
{
    internal sealed class BasicSelector
    {
        public static SelectIntruction PrepareInstructions(ISelectClauseNode parseRoot)
        {
            var res = new SelectIntruction { ArrayLength = parseRoot.GetList().Select(z => z.Letter).Max() + 1 };
            foreach (var e in parseRoot.GetList())
            {
                var ins = new LetterInstruction { LetterIndex = e.Letter, IsRoot = e.Parent == null };
                if (!ins.IsRoot)
                {
                    ins.ParentIndex = e.Parent.Letter;
                    ins.ChildNumberInArray = e.Parent.Children.IndexOf(e);
                    ins.LeftBrotherIndexes = e.Parent.Children.Take(ins.ChildNumberInArray).Select(z => z.Letter).ToArray();
                }
                else
                {
                    ins.LeftBrotherIndexes = new int[] { };
                }

                if (e.Children.Count != 0)
                {
                    if (e.Children.Count != 0)
                    {
                        var sub = Math.Sign(e.Children.Count(z => z.Recursive == LetterRecursionType.Subtree));
                        var child = Math.Sign(e.Children.Count(z => z.Recursive == LetterRecursionType.Children));
                        var clear = Math.Sign(e.Children.Count(z => z.Recursive == LetterRecursionType.No));
                        if (sub + child + clear > 1) throw new Exception("Error in axiom: letter " + (char)('A' + e.Letter) + " must have only one type of childs (for example A(?B,.C) is not acceptable)");
                        if (clear != 0)
                            ins.Arity = e.Children.Count;
                    }
                }

                ins.Recursive = e.Recursive;
                res.Letters.Add(ins);
            }
            return res;
        }

        readonly SelectIntruction _instruction;

        public BasicSelector(ISelectClauseNode clause)
        {
            _instruction = PrepareInstructions(clause);
        }

        public IEnumerable<INode[]> Select(INode root)
        {
            var result = new INode[_instruction.ArrayLength];
            var currentInstruction = 0;
            _instruction.Letters[0].Reset();

            while (true)
            {
                if (currentInstruction == -1) break;

                if (_instruction.Letters[currentInstruction].ApplyInstruction(result, root))
                {
                    currentInstruction--;
                    continue;
                }

                currentInstruction++;
                if (currentInstruction == _instruction.Letters.Count)
                {
                    yield return result.ToArray();
                    currentInstruction--;
                    continue;
                }
                _instruction.Letters[currentInstruction].Reset();
            }
        }
    }
}
