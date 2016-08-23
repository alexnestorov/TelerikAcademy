namespace Abstraction.Exceptions
{
    using System;

    public class FigureException : Exception
    {
        public FigureException(string msg)
            : base(msg)
        {
        }
    }
}