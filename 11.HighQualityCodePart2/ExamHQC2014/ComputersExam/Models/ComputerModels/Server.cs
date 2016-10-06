using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;
using ComputersExam.Contracts;
using ComputersExam.Models.VideoCardModels;

namespace ComputersExam.Models.ComputerModels
{
    public class Server : Computer
    {
        public Server(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.VideoCard = new MonochromeVideoCard();
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
