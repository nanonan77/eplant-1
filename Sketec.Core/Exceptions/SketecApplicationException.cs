using System;

namespace Sketec.Core.Exceptions
{
    public class SketecApplicationException : Exception
    {
        public string Code { get; private set; }

        public SketecApplicationException(string message, string code) : base(message)
        {
            Code = code.ToLower();
        }

        public SketecApplicationException(string message, string code, Exception innerException) : base(message, innerException)
        {
            Code = code.ToLower();
        }
    }
}
