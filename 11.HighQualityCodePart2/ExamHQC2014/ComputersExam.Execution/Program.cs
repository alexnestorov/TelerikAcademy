using System;
using System.Collections.Generic;

using ComputersExam.Common;
using ComputersExam.Exceptions;
using ComputersExam.Manufacturer;
using ComputersExam.Models.CpuModels;
using ComputersExam.Models.ComputerModels;
using Computers.Common.Components;
using ComputersExam.Models.VideoCardModels;

namespace ComputersExam.Execution
{
    public class Program
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            IComputerFactory computerFactory;
            if (manufacturer == "HP")
            {
                computerFactory = new HpComputerFactory();
            }
            else if (manufacturer == "Dell")
            {
                computerFactory = new DellComputerFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            pc = computerFactory.CreatePC(new Cpu32(2), new Ram(4), new List<HardDrive>() { new HardDrive(500) }, new RGBVideoCard());

            server = computerFactory.CreateServer(
                new Cpu64(4),
                new Ram(8),
                new List<HardDrive>() { new HardDrive(500) },
                new MonochromeVideoCard()
                );

            laptop = computerFactory.CreateLaptop(
                new Cpu32(2),
                new Ram(4),
                new List<HardDrive>() { new HardDrive(1000) },
                new RGBVideoCard(),
                new LaptopBattery()
                );

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null)
                {
                    break;
                }

                if (command.StartsWith("Exit"))
                {
                    break;
                }

                var commandParameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandParameters[0];
                var commandArgument = int.Parse(commandParameters[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}