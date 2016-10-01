using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;
using ComputersExam.Enums;

namespace ComputersExam.Models
{
    public class Server : Computer
    {
        public Server(Cpu cpu, Ram ram, IEnumerable<VideoCard> hardDrives, VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.VideoCard.IsMonochrome = true;
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);

            // TODO: Fix it
            this.Cpu.SquareNumber(data);
        }
    }
}
