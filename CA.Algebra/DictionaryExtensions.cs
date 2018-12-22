using System.Collections.Generic;
using System.Linq;

namespace AIRLab.CA.Algebra
{
    internal static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> collection)
        {
            collection
                .Where(item => !source.ContainsKey(item.Key))
                .ToList()
                .ForEach(item => source.Add(item.Key, item.Value));
        }
    }
}