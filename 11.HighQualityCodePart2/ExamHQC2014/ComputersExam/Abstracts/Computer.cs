using ComputersExam.Common;
using System.Collections.Generic;

namespace ComputersExam.Abstracts
{
    public abstract class Computer
    {
        public Computer(Cpu cpu, Ram ram, IEnumerable<VideoCard> hardDrives, VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected IEnumerable<VideoCard> HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Ram Ram { get; set; }
    }
}
