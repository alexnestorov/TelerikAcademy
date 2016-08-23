namespace CohesionAndCoupling.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class ParameterOutOfRangeException : ArgumentOutOfRangeException
    {
        public ParameterOutOfRangeException()
        {
        }

        public ParameterOutOfRangeException(string message) : base(message)
        {
        }

        public ParameterOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParameterOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}