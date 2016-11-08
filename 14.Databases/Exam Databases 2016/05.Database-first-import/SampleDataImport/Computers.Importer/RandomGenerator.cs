using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Importer
{
    public static class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private static Random random = new Random();


        public static int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = random.Next(minLength, maxLength);
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var currenRandomSymbol = Alphabet[random.Next(0, Alphabet.Length)];
                result.Append(currenRandomSymbol);
            }

            return result.ToString();
        }
    }
}
