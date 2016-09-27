using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;

namespace ComputersExam.Models
{
    public class Server : Computer
    {
        public Server(Cpu cpu, Rammstein ram, IEnumerable<HardDriver> hardDrives, HardDriver videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.VideoCard.IsMonochrome = true;
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);

            // TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
