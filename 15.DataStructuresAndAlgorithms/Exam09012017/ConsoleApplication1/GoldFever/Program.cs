using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] lowPrices = new int[n];
        long profit = 0;
        int money = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            var current = prices[i];
            if (money <= current)
            {
                lowPrices[i] = 0;
                money = current;
            }
            profit += money - current;
        }

        Console.WriteLine(profit);
    }
}