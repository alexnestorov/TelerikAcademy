using System;

using ComputersExam.Common;
using ComputersExam.Contracts;

namespace ComputersExam.Abstracts
{

    public abstract class Cpu : MotherboardPart, ICpu
    {
        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;

        internal Cpu(byte numberOfCores)
        {
            this.CoresNumber = numberOfCores;
        }

        public byte CoresNumber { get; }

        protected virtual int MaxCapacity { get; }

        public void SquareNumber()
        {
            var data = this.Motherboard.LoadRamValue();
            if (data < 0)
            {
                this.Motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > this.MaxCapacity)
            {
                this.Motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                long value = data * data;

                this.Motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public void GenerateRandomValue(int minimumRandomValue, int maximumRandomValue)
        {
            int randomNumber = Random.Next(minimumRandomValue, maximumRandomValue);

            this.Motherboard.SaveRamValue(randomNumber);
        }
    }
}