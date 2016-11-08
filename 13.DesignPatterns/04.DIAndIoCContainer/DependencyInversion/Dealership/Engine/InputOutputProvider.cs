using System;
using Dealership.Contracts;

namespace Dealership.Engine
{
    public class InputOutputProvider : IInputOutputProvider
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
