using System;

namespace AIRLab.CA.Exceptions
{
    public sealed class ParseException : ComputerAlgebraException
    {
        public ParseException(string message)
            : base(message)
        { }

        public ParseException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public ParseException()
        {
        }
    }
}