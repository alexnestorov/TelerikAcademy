using System;

using ComputersExam.Common;
using ComputersExam.Contracts;

namespace Computers.Common.Components
{
    public class RGBVideoCard : MotherboardPart, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}