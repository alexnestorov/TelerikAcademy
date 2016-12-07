using System;
using System.Collections.Generic;

namespace SortingAndSearchingApp
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int low, int high)
        {
            if (low < high)
            {
                var p = Partition(collection, low, high);
                Sort(collection, low, p - 1);
                Sort(collection, p + 1, high);
            }
        }

        private int Partition(IList<T> collection, int low, int high)
        {
            var pivot = collection[low];

            var index = high;

            for (int i = index; i > low; i--)
            {
                if (collection[i].CompareTo(pivot) > 0)
                {
                    Swap(collection, i, index);
                    index--;
                }
            }

            Swap(collection, index, low);
            return index;
        }

        private void Swap(IList<T> collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
    }
}
