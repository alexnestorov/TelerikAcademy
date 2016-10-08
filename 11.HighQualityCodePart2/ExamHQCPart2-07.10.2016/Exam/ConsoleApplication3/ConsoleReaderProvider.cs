using System;

using ConsoleApplication3.Contracts;

namespace ConsoleApplication3
{
    public class ConsoleReaderProvider : IReader
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string Provider()
        {
            return Console.ReadLine();
        }
    }
}
