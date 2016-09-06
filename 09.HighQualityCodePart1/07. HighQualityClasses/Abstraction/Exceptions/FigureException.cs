namespace Abstraction.Exceptions
{
    using System;

    [Serializable]
    public class FigureException : Exception
    {
        public FigureException(string msg)
            : base(msg)
        {
        }
    }
}