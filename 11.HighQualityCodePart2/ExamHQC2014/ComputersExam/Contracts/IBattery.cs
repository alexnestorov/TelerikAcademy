namespace ComputersExam.Contracts
{
    public interface IBattery
    {
        int Percentage { get; set; }

        void Charge(int percentage);
    }
}
