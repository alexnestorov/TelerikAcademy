using System;
using System.Diagnostics;

namespace Assertions.Extensions
{
   public static class Sorting
    {
        public static void SelectionSort<T>(T[] arr)
            where T : IComparable<T>
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Equals(null), "Array can not be null.");
            Debug.Assert(arr.Length.Equals(0), "Array length can not be empty.");

            Debug.Assert(startIndex < 0 || startIndex >= arr.Length, "Start index can not be outside of array boundaries.");
            Debug.Assert(endIndex < 0 || endIndex >= arr.Length, "End index can not be outside of array boundaries.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x.Equals(null), "X can not be null.");
            Debug.Assert(y.Equals(null), "Y can not be null.");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
