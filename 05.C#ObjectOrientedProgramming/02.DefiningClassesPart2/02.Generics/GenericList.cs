namespace _02.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericList<T> where T : IComparable, IComparable<T>, new()
    {
        // Fields.
        private const int InitialCapacity = 4;
        private int count;
        private int capacity;

        // Properties.
        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value < InitialCapacity)
                {
                    throw new ArgumentOutOfRangeException("Capacity can not be less than Initial Capacity, which is set to be at least 1.");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }
        public int Count
        {
            get { return this.count; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count can not be less than 0.");
                }
                this.count = value;
            }
        }

        public T[] List { get; set; }

        // Indexer for GenericList
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range exception.");
                }
                return this.List[index]; }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range exception.");
                }
                this.List[index] = value; }
        }
        // Constructor.
        public GenericList(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.List = new T[this.Capacity];
        }

        // Methods.
        private void DoubleCapacity()
        {
            T[] newList = new T[this.Count * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newList[i] = this.List[i];
            }
            this.List = newList;
        }
        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity *= 2;
                DoubleCapacity();
            }
            this.Count ++;
            this.List[this.Count - 1] = element;
        }
        public int IndexAt(T element)
        {
            int index = -1;
            foreach (var item in List)
            {
                index++;
                if (item.CompareTo(element) == 0)
                {
                    return index;
                }
            }
            throw new ArgumentOutOfRangeException("Element doesn't exist in current collection");
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Can not remove index at this position, because it's outside of boundaries of current collection");
            }
            for (int i = index + 1; i < this.Count; i++)
            {
                this.List[i - 1] = this.List[i];
            }
            this.Count--;
        }
        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Can not insert element at this position, because it's outside of boundaries of current collection");
            }
            for (int i = this.Count - 1; i > index; i--)
            {
                this.List[i + 1] = this.List[i];
            }
            this.List[index] = element;
            this.Count++;
        }
        public void Clear()
        {
            this.Capacity = InitialCapacity;
            this.Count = 0;
            this.List = new T[this.Capacity];
        }
        public int IndexOf(T element)
        {
            int index = -1;
            foreach (var item in List)
            {
                index++;
                if (item.CompareTo(element) == 0)
                {
                    return index;
                }
            }
            return index = -1;
        }

        // Methods.
        public T Max()
        {
            T max = default(T);
            if (this.Count > 0)
            {
                max = this.List[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.List[i].CompareTo(max) > 0)
                    {
                        max = this.List[i];
                    }
                }
            }
            return max;
        }

        public T Min()
        {
            T min = default(T);
            if (this.Count > 0)
            {
                min = this.List[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.List[i].CompareTo(min) < 0)
                    {
                        min = this.List[i];
                    }
                }
            }
            return min;
        }

        public override string ToString()
        {
            string[] temp = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                temp[i] = this.List[i].ToString();
            }
            return String.Join(", ", temp);
        }
    }
}
