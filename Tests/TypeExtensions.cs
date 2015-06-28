using System;

namespace AIRLab.CA.Tests
{
    internal static class TypeExtensions
    {
        public static T Clone<T>(this T source)
            where T : ICloneable
        {
            return (T)source.Clone();
        }
    }
}