using System.Collections.Generic;

using ComputersExam.Abstracts;
using ComputersExam.Common;

namespace ComputersExam.Models
{
    public class Laptop : Computer
    {
        private readonly LaptopBattery battery;

        internal Laptop(Cpu cpu, Ram ram, IEnumerable<VideoCard> hardDrives, VideoCard videoCard, LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard )
        {
            this.battery = battery;
        }

        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }
    }
}
