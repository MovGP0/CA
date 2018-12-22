﻿// ComputerAlgebra Library
//
// Copyright © Medvedev Igor, Okulovsky Yuri, Borcheninov Jaroslav, Johann Dirry, 2014
// imedvedev3@gmail.com, yuri.okulovsky@gmail.com, yariksuperman@gmail.com, johann.dirry@aon.at
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AIRLab.CA.Nodes;

namespace AIRLab.CA.Nodes
{
    public static class NodeExtensions
    {
        public static int IndexOfChild(this INode node, INode child)
        {
            for (var i = 0; i < node.Children.Length; i++)
                if (node.Children[i] == child) return i;
            return -1;
        }

        public static bool IsRoot(this INode node)
        {
            return node.Parent == null;
        }

        public static bool HasChildren(this INode node)
        {
            return node.Children != null && node.Children.Length != 0;
        }

        public static int GetOperationCount(this INode node)
        {
            return 1 + node.Children?.Select(GetOperationCount).Sum() ?? 1;
        }

        public static int GetVariableCount(this INode node)
        {
            return node.AsEnumerable()
                .OfType<VariableNode>()
                .Select(v => v.Index)
                .Distinct()
                .Count();
        }

        public static IEnumerable<INode> AsEnumerable(this INode node)
        {
            var nodes = new[] { node };
            return node.Children == null ? nodes : nodes.Union(node.Children.SelectMany(AsEnumerable));
        }

        public static Func<IList, T> ComplileDelegate<T>(this INode parent)
        {
            var arguments = Expression.Parameter(typeof(IList));
            return Expression.Lambda<Func<IList, T>>(Expression.Invoke(parent.BuildExpression(), arguments), arguments).Compile();
        }

        public static IEnumerable<INode> GetSubTree(this INode node)
        {
            var stopParent = node.Parent;
            while (true)
            {
                yield return node;
                if (node.HasChildren())
                {
                    node = node.Children[0];
                    continue;
                }
                while (true)
                {
                    var parent = node.Parent;
                    if (parent == stopParent) yield break;
                    var index = parent.IndexOfChild(node);
                    if (index < parent.Children.Length - 1)
                    {
                        node = parent.Children[index + 1];
                        break;
                    }
                    node = parent;
                }
            }
        }

        public static INode SwitchCoupleOfChildren(this INode node)
        {
            if (!node.HasChildren() || node.Children.Length != 2)
            {
                return null;
            }

            var first = node.Children[0];
            var second = node.Children[1];
            node.Children[0] = second;
            node.Children[1] = first;
            return node;
        }

        public static void ReplaceChildren(this INode node, INode oldChild, INode newChild)
        {
            node.Children[node.IndexOfChild(oldChild)] = (INode)newChild.Clone();
        }

        public static bool TestRoot(this INode node)
        {
            if (node.Parent != null)
                return false;
            foreach (var e in node.GetSubTree())
            {
                if (e.Children.Count(z => z == null) != 0) return false;
                var f = e.Parent;
                while (f != null)
                {
                    if (f == e) return false;
                    f = f.Parent;
                }
            }
            return true;
        }

        public static string ToPrefixForm(this INode node)
        {
            var name = node.GetType().CleanTypeName();
            if (name == "Constant") return $"Constant({node})";
            return name == "VariableNode"
                ? $"VariableNode({string.Join("|", ((VariableNode)node).Index, node.ToString())})"
                : $"{name}({GetChildrenRepresenation(node)})";
        }

        private static string GetChildrenRepresenation(INode node)
        {
            var values = node.Children.Select(c => c.ToPrefixForm())
                .ToArray();
            return string.Join(",", values);
        }
    }
}