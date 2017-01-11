using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingsAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var adjList = new List<int>[n+1];
            for (int i = 1; i <= n; i++)
            {
                int hangRing = int.Parse(Console.ReadLine());
                if (adjList[hangRing] != null)
                {
                    adjList[hangRing].Add(i);
                }
                else
                {
                    adjList[hangRing] = new List<int>();
                    adjList[hangRing].Add(i);
                }
            }

            var answer = 1;
            foreach (var item in adjList)
            {
                if (item != null)
                {
                    var currentAnswer = 1;

                    if (item[0] != 0)
                    {
                        for (int i = 1; i <= item.Count; i++)
                        {
                            currentAnswer *= i;
                        }
                    }

                    answer *= currentAnswer;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
