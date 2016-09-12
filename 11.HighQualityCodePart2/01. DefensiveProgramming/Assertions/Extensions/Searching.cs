using System;
using System.Diagnostics;

namespace Assertions.Extensions
{
    public static class Searching
    {
        public static int BinarySearch<T>(T[] arr, T value)
            where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Equals(null), "The input array is null.");
            Debug.Assert(arr.Length.Equals(0), "The input array can not be empty.");

            Debug.Assert(value.Equals(null), "The value can not be null.");

            // Debug.Assert((dynamic)value >= 0 && (dynamic)value < arr.Length, "Value must be index in array.");
            Debug.Assert(startIndex < 0 || startIndex >= arr.Length, "Start index is outside of array boundaries.");
            Debug.Assert(endIndex < 0 || endIndex >= arr.Length, "End index is outside of array boundaries.");
            Debug.Assert(startIndex > endIndex, "Start index must be lower than End index.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
