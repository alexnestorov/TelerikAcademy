namespace ComputersExam.Contracts
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string newStorageData);

        string LoadData(int address);
    }
}
