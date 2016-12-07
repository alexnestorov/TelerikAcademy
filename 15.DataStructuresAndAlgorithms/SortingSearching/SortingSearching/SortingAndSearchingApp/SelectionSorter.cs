using System;
using System.Collections.Generic;

namespace SortingAndSearchingApp
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[i]) < 0)
                    {
                        Swap(collection, i, j);
                    }
                }
            }
        }

        private static void Swap(IList<T> collection, int i, int j)
        {
            T temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
    }
}
