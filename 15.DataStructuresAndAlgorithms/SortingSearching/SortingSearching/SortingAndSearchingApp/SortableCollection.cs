using System;
using System.Collections.Generic;

namespace SortingAndSearchingApp
{
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (item.CompareTo(this.Items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return BinarySearch(this.Items, item, 0, this.Items.Count - 1);
        }

        private bool BinarySearch(IList<T> collection, T item, int imin, int imax)
        {
            if (imax <= imin)
            {
                return false;
            }
            else
            {
                int imid = (imin + imax) / 2;

                if (collection[imid].CompareTo(item) > 0)
                {
                    return BinarySearch(collection, item, imin, imid);
                }
                else if (collection[imid].CompareTo(item) < 0)
                {
                    return BinarySearch(collection, item, imid + 1, imax);
                }
                else
                {
                    return true;
                }
            }

        }


        public void Shuffle()
        {

            var rand = new Random();
            for (int i = this.Items.Count - 1; i > 0; i--)
            {
                var random = rand.Next(0, i + 1);
                Swap(this.Items, random, i);
            }

        }

        private void Swap(IList<T> collection, int i, int j)
        {
            T temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
