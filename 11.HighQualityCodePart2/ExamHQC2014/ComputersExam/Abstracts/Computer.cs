/// <summary>
///     Abstract class for creating an instance of different type of computer.
/// </summary>
using ComputersExam.Common;
using System.Collections.Generic;

using ComputersExam.Contracts;

namespace ComputersExam.Abstracts
{
    /// <summary>
    /// Creating a Computer object in every child inheritant.
    /// Uses the base logic of this class to initialize all properties and methods.
    /// </summary>
    public abstract class Computer
    {
        /// <summary>
        /// Base Constructor for creating an instance of each computer which inherits this class.
        /// </summary>
        /// <param name="cpu" Basic dependency. Needs an motherboard and number of cores></param>
        /// <param name="ram"></param>
        /// <param name="hardDrives"></param>
        /// <param name="videoCard"></param>
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
