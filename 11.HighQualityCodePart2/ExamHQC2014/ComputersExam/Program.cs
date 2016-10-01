using System;
using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;
using ComputersExam.Exceptions;
using ComputersExam.Models;
using ComputersExam.Manufacturer;
using ComputersExam.Enums;

namespace ComputersExam
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

            pc = computerFactory.CreatePC(2, ProcessorType.High, new Ram(4), new VideoCard());

            server = computerFactory.CreateServer(
                new Cpu(4, ProcessorType.High, new Ram(8), new VideoCard()),
                new Ram(16),
                new List<VideoCard>() { new VideoCard()},
                new VideoCard()
                );

            laptop = computerFactory.CreateLaptop(
                new Cpu(2, ProcessorType.High, new Ram(4), new VideoCard()),
                new Ram(4),
                new List<VideoCard>() { new VideoCard() },
                new VideoCard(),
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