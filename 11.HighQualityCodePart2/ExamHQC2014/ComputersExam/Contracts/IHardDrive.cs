namespace ComputersExam.Contracts
{
    public interface IHardDrive : IMotherboardPart
    {
        int Capacity { get; }

        void SaveData(int address, string newStorageData);

        string LoadData(int address);
    }
}
