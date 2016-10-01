using System;

using ComputersExam.Models;
using ComputersExam.Common;
using System.Collections;
using System.Collections.Generic;
using ComputersExam.Enums;

namespace ComputersExam.Manufacturer
{
    public class DellComputerFactory : IComputerFactory
    {
        public Laptop CreateLaptop(Cpu laptopCpu, Ram laptopRam, IEnumerable<VideoCard> hardDrives, VideoCard laptopVideoCard, LaptopBattery battery)
        {
            var laptop = new Laptop(
                laptopCpu,
                laptopRam,
                hardDrives,
                laptopVideoCard,
                battery);

            return laptop;
        }

        public PersonalComputer CreatePC(byte numberOfCores, ProcessorType numberOfBits, Ram ram, VideoCard videoCard)
        {
            var pc = new PersonalComputer(
                new Cpu(numberOfCores, numberOfBits, ram, videoCard),
                ram,
                new[] { new VideoCard(500, false, 0) },
                videoCard);

            return pc;
        }

        public Server CreateServer(Cpu serverCpu, Ram serverRam, IEnumerable<VideoCard> hardDrives, VideoCard serverVideoCard)
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
