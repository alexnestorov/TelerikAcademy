namespace Abstraction.Common
{
    using System;

    using Exceptions;

    public static class Validator
    {
        public static void ValidateFigureParameter(double parameter, string name)
        {
            if (parameter <= 0)
            {
                throw new FigureException(String.Format("The {0} must be a positive number!", name));
            }
        }
    }
}