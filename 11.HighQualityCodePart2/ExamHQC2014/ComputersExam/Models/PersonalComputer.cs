using ComputersExam.Abstracts;
using ComputersExam.Common;
using System.Collections.Generic;

namespace ComputersExam.Models
{
    public class PersonalComputer : Computer
    {
        public PersonalComputer(Cpu cpu, Ram ram, IEnumerable<VideoCard> hardDrives, VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = this.Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
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
