namespace ComputersExam.Contracts
{
    public interface ICpu
    {
        byte CoresNumber { get; }

        void GenerateRandomValue(int min, int max);

        void SquareNumber();
    }
}
