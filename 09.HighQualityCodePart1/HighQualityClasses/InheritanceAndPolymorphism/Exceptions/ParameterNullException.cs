namespace CohesionAndCoupling.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class ParameterNullException : ArgumentNullException
    {
        public ParameterNullException()
        {
        }

        public ParameterNullException(string message)
            : base(message)
        {
        }

        public ParameterNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ParameterNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}