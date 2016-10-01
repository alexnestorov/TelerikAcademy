using System.Collections.Generic;

using ComputersExam.Common;
using ComputersExam.Models;
using ComputersExam.Enums;

namespace ComputersExam.Manufacturer
{
    public interface IComputerFactory
    {
        PersonalComputer CreatePC(byte numberOfCores, ProcessorType numberOfBits, Ram ram, VideoCard videoCard);

        Laptop CreateLaptop(Cpu laptopCpu, Ram laptopRam, IEnumerable<VideoCard> hardDrives, VideoCard laptopVideoCard, LaptopBattery battery);

        Server CreateServer(Cpu serverCpu, Ram serverRam, IEnumerable<VideoCard> hardDrives, VideoCard serverVideoCard);
    }
}
