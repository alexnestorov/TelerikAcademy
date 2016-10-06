using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Contracts;

namespace ComputersExam.Models.ComputerModels
{
    public class PersonalComputer : Computer
    {
        public PersonalComputer(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomValue(1, 10);
            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }
    }
}
