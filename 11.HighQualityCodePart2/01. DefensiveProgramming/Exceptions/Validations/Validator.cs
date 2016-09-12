using System;
using System.Collections.Generic;
using System.Linq;

using Exceptions.Extensions;

namespace Exceptions.Validations
{
    public static class Validator
    {
        public static void IsValidNumber(int value, int? min, int? max)
        {
            if (value < min || value > max)
            {
                throw new ScoreOutOfRangeException("The {0} must be between {1} and {2}", value, min, max);
            }
        }

        public static void IsStringNull(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("The {0} cannot be null or empty", name);
            }
        }

        public static void IsObjectNull(int value, string name)
        {
            if (value.Equals(null))
            {
                throw new ArgumentNullException("The {0} cannot be null", name);
            }
        }

        public static void IsArrayNullOrEmpty<T>(IEnumerable<T> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("The array cannot be null");
            }

            if (value.Count() == 0)
            {
                throw new ScoreOutOfRangeException("The array is empty");
            }
        }

    }
}
