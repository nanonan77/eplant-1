using System;

namespace Sketec.Core.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message) : base(message)
        {
        }
    }
}
