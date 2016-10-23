namespace FacadePattern.Contracts
{
    public interface IBank
    {
        bool HasSufficientSavings(ICustomer currentCustomer, int amount);
    }
}