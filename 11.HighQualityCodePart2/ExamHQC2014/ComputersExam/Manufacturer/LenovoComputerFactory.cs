using System.Collections.Generic;

using ComputersExam.Models;
using ComputersExam.Common;
using ComputersExam.Enums;
using ComputersExam.Contracts;
using ComputersExam.Models.ComputerModels;
using ComputersExam.Models.CpuModels;

namespace ComputersExam.Manufacturer
{
    public class LenovoComputerFactory : IComputerFactory
    {
        public Laptop CreateLaptop(ICpu laptopCpu, IRam laptopRam, IEnumerable<IHardDrive> hardDrives, IVideoCard laptopVideoCard, IBattery battery)
        {
            var laptop = new Laptop(
                laptopCpu,
                laptopRam,
                hardDrives,
                laptopVideoCard,
                battery);

            return laptop;
        }

        public PersonalComputer CreatePC(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard)
        {
            var pc = new PersonalComputer(
                cpu,
                ram,
                hardDrives,
                videoCard);

            return pc;
        }

        public Server CreateServer(ICpu serverCpu, IRam serverRam, IEnumerable<IHardDrive> hardDrives, IVideoCard serverVideoCard)
        {
            var server = new Server(
                serverCpu,
                serverRam,
                hardDrives,
                serverVideoCard);

            return server;
        }
    }
}
