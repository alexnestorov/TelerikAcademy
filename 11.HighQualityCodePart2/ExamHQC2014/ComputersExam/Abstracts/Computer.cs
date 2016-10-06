using ComputersExam.Common;
using System.Collections.Generic;

using ComputersExam.Contracts;

namespace ComputersExam.Abstracts
{
    public abstract class Computer
    {
        public Computer(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.Motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected IEnumerable<IHardDrive> HardDrives { get; set; }

        protected IVideoCard VideoCard { get; set; }

        protected ICpu Cpu { get; set; }

        protected IRam Ram { get; set; }

        private Motherboard Motherboard { get; }
    }
}
