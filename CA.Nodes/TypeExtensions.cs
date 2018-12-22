using System;

namespace AIRLab.CA.Nodes
{
    internal static class TypeExtensions
    {
        public static string CleanTypeName(this Type type)
        {
            var name = type.Name;
            return !type.IsGenericType
                ? name
                : name.Remove(name.IndexOf('`'));
        }
    }
}