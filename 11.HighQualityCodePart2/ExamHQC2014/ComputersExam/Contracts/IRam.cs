namespace ComputersExam.Contracts
{
    public interface IRam : IMotherboardPart
    {
        int MemoryCapacity { get; set; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
