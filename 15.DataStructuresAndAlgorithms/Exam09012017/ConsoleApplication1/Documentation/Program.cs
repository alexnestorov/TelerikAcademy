using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var reverse = text.Where(x => x != ' ').ToArray();
            Array.Reverse(reverse);
            if (reverse.Equals(text))
            {
                Console.WriteLine("0");
                return;

                int counter = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == reverse[i] || !Char.IsLetter(text[i]))
                    {
                        continue;
                    }
                    else
                    {
                        reverse[i] = text[i];
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
