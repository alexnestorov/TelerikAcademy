using ComputersExam.Contracts;

namespace ComputersExam.Common
{
    public class Ram : MotherboardPart, IRam
    {
        private int value;

        public Ram(int a)
        {
            this.MemoryCapacity = a;
        }

        public int MemoryCapacity { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}