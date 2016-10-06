using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;
using ComputersExam.Contracts;

namespace ComputersExam.Models.ComputerModels
{
    public class Laptop : Computer
    {
        private readonly IBattery battery;

        public Laptop(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard, IBattery battery)
            : base(cpu, ram, hardDrives, videoCard )
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }
    }
}
