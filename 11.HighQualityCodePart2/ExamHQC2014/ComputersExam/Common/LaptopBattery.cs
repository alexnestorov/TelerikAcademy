using ComputersExam.Contracts;

namespace ComputersExam.Common
{
    public class LaptopBattery : IBattery
    {
        public const int InitialBatteryPercentage = 100 / 2;
        public const int MaximalBatteryPercentage = 100;
        public const int MinimalBatteryPercentage = 0;

        internal LaptopBattery()
        {
            this.Percentage = InitialBatteryPercentage;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;
            if (this.Percentage > MaximalBatteryPercentage)
            {
                this.Percentage = MaximalBatteryPercentage;
            }

            if (this.Percentage < MinimalBatteryPercentage)
            {
                this.Percentage = MinimalBatteryPercentage;
            }
        }
    }
}