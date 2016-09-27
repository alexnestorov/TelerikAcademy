using System;
using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;
using ComputersExam.Exceptions;
using ComputersExam.Models;

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
            if (manufacturer == "HP")
            {
                InitializeHp();
            }
            else if (manufacturer == "Dell")
            {
                InitializeDell();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

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

        private static void InitializeHp()
        {
            var ram = new Rammstein(8 / 4);
            var videoCard = new HardDriver() { IsMonochrome = false };
            var pc = new PersonalComputer(
                new Cpu(8 / 4, 32, ram, videoCard),
                ram,
                new[] { new HardDriver(500, false, 0) },
                videoCard);

            var serverRam = new Rammstein(8 * 4);
            var serverVideo = new HardDriver();
            var server = new Server(
                new Cpu(8 / 2, 32, serverRam, serverVideo),
                serverRam,
                new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) }) },
                serverVideo);
            {
                var card = new HardDriver()
                {
                    IsMonochrome = false
                };
                var ram1 = new Rammstein(8 / 2);
                var laptop = new Laptop(
                    new Cpu(8 / 4, 64, ram1, card),
                    ram1,
                    new[] { new HardDriver(500, false, 0) },
                    card,
                    new LaptopBattery());
            }
        }

        private static void InitializeDell()
        {
            var ram = new Rammstein(8);
            var videoCard = new HardDriver() { IsMonochrome = false };
            var pc = new PersonalComputer(
                new Cpu(8 / 2, 64, ram, videoCard),
                ram,
                new[] { new HardDriver(1000, false, 0) },
                videoCard);

            var ram1 = new Rammstein(8 * 8);
            var card = new HardDriver();
            var server = new Server(
                new Cpu(8, 64, ram1, card),
                ram1,
                new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) }) },
                card);

            var ram2 = new Rammstein(8);
            var videoCard1 = new HardDriver() { IsMonochrome = false };
            var laptop = new Laptop(
                new Cpu(8 / 2, 32, ram2, videoCard1),
                ram2,
                new[] { new HardDriver(1000, false, 0) },
                videoCard1,
                new LaptopBattery());
        }
    }
}