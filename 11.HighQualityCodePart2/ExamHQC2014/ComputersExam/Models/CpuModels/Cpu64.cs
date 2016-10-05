using ComputersExam.Abstracts;

namespace ComputersExam.Models.CpuModels
{
    public class Cpu64 : Cpu
    {
        private readonly int maxCapacity;

        public Cpu64(byte coresNumber)
            : base(coresNumber)
        {
            this.maxCapacity = 1000;
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
