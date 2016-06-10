namespace _02.Generics

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Generics
    {
        static void Main()
        {
            var list = new GenericList<double>();
            var defaultList = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                list.Add(i + 0.5);
                defaultList.Add((i + 1) * 2);
            }
            list.InsertAt(0,10.1);
            list.IndexAt(4.5);
            list.IndexOf(4.5);
            list.RemoveAt(8);
            list.Min();
            list.Max();
            Console.WriteLine("Max value: " + list.Max());
            Console.WriteLine("Min value: " + list.Min());
            Console.WriteLine("Index of: " + list.IndexOf(4.5));
            Console.WriteLine("Index at: " + list.IndexOf(3.5));
            Console.WriteLine("Override method ToString: " + list.ToString());

            list.Clear();
            Console.WriteLine("Elements in GenericList after clear: " + list.Count);
        }
    }
}
