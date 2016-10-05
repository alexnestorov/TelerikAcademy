using ComputersExam.Abstracts;

namespace ComputersExam.Models.CpuModels
{
    public class Cpu128 : Cpu
    {
        private readonly int maxCapacity;

        public Cpu128(byte coresNumber)
            : base(coresNumber)
        {
            this.maxCapacity = 2000;
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
