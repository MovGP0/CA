using System;

namespace AIRLab.CA.Exceptions
{
    public abstract class ComputerAlgebraException : ApplicationException
    {
        public ComputerAlgebraException(string message) : base(message)
        { }

        public ComputerAlgebraException(string message, Exception innerException)
            : base(string.Format("{0}{2}Inner exception message: {1}", message, innerException.Message, Environment.NewLine), innerException)
        { }

        public ComputerAlgebraException() : base()
        {
        }
    }
}
