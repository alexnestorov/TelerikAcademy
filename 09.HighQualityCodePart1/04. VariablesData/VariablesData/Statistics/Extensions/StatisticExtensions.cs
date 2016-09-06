using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesData.Statistics.Extensions
{
    public static class StatisticExtensions
    {
        public static void PrintStatistics<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            Console.WriteLine(string.Format("The array statistics are as follows\n{0}", new string('-', 35)));
            Console.WriteLine(string.Format("Max: {0}", arrayOfElements.CalculateMax()));
            Console.WriteLine(string.Format("Min: {0}", arrayOfElements.CalculateMin()));
            Console.WriteLine(string.Format("Average: {0}", arrayOfElements.CalculateAverage()));
        }

        private static T CalculateMax<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            return arrayOfElements.Max();
        }

        private static T CalculateMin<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            return arrayOfElements.Min();
        }

        private static T CalculateAverage<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            dynamic sum = arrayOfElements.Aggregate<T, dynamic>(0, (current, element) => current + element);

            return (T)(sum / arrayOfElements.Count());
        }
    }
}
