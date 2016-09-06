namespace CohesionAndCoupling.Common
{
    using Exceptions;

    public static class Validator
    {
        public static void ValidateProperty(double figureParameter, object propertyName)
        {
            if (figureParameter <= 0)
            {
                throw new ParameterOutOfRangeException(string.Format("The {0} can not be zero or negative number!", propertyName));
            }
        }
    }
}
