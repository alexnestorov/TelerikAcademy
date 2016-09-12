using System;
using System.Linq;
using System.Diagnostics;
using Assertions.Extensions;

namespace Assertions
{
    public class StartUp
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            Sorting.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            Sorting.SelectionSort(new int[0]); // Test sorting empty array
            Sorting.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(Searching.BinarySearch(arr, -1000));
            Console.WriteLine(Searching.BinarySearch(arr, 0));
            Console.WriteLine(Searching.BinarySearch(arr, 17));
            Console.WriteLine(Searching.BinarySearch(arr, 10));
            Console.WriteLine(Searching.BinarySearch(arr, 1000));
        }
    }
}
