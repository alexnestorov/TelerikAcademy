using System.Collections.Generic;

using ComputersExam.Common;
using ComputersExam.Enums;
using ComputersExam.Models.ComputerModels;
using ComputersExam.Contracts;

namespace ComputersExam.Manufacturer
{
    public interface IComputerFactory
    {
        PersonalComputer CreatePC(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard);

        Laptop CreateLaptop(ICpu laptopCpu, IRam laptopRam, IEnumerable<IHardDrive> hardDrives, IVideoCard laptopVideoCard, IBattery battery);

        Server CreateServer(ICpu serverCpu, IRam serverRam, IEnumerable<IHardDrive> hardDrives, IVideoCard serverVideoCard);
    }
}
