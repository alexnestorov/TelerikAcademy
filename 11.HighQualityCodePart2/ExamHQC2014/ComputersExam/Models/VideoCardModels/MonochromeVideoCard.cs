using System;

using ComputersExam.Common;
using ComputersExam.Contracts;

namespace ComputersExam.Models.VideoCardModels
{

    public class MonochromeVideoCard : MotherboardPart, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}