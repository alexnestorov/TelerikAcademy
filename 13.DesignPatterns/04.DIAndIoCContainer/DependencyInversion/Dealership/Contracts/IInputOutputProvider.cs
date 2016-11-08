namespace Dealership.Contracts
{
   public interface IInputOutputProvider
    {
        string Read();

        void Write(string message);
    }
}
