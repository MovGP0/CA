using System.Collections.Generic;
using System.Linq;

namespace AIRLab.CA.Nodes
{
    internal static class EnumerableExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> obj, T value)
        {
            return obj
                .Select((a, i) => (a.Equals(value)) ? i : -1)
                .Max();
        }
    }
}