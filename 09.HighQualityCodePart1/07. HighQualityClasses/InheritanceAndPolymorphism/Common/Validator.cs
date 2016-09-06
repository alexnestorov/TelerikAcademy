namespace CohesionAndCoupling.Common
{
    using Exceptions;

    public static class Validator
    {
        public static void ValidateProperty(object property, object propertyName)
        {
            if (property.Equals(null))
            {
                throw new ParameterNullException(string.Format("The {0} can not be null!", propertyName));
            }
        }
    }
}
