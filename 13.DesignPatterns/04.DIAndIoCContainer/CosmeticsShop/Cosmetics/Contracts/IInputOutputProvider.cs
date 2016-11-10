namespace Cosmetics.Contracts
{
    public interface IInputOutputProvider
    {
        string Read();

        void Write(string message);
    }
}
