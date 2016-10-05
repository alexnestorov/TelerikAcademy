using System;

using ComputersExam.Abstracts;

namespace ComputersExam.Models.CpuModels
{
    public class Cpu32 : Cpu
    {
        private readonly int maxCapacity;

        public Cpu32(byte coresNumber)
            : base(coresNumber)
        {
            this.maxCapacity = 500;
        }

        protected override int MaxCapacity
        {
            get
            {
                return this.maxCapacity;
            }
        }
    }
}
