using System;

namespace ComputersExam.Exceptions
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}
