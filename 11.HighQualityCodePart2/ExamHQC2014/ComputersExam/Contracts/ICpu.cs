namespace ComputersExam.Contracts
{
    public interface ICpu : IMotherboardPart
    {
        byte CoresNumber { get; }

        void GenerateRandomValue(int min, int max);

        void SquareNumber();
    }
}
