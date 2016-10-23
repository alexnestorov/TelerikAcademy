namespace FacadePattern.Contracts
{
    public interface ICredit
    {
        bool HasGoodCredit(ICustomer currentCustomer);
    }
}