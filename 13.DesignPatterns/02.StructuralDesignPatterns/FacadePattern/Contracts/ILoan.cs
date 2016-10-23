namespace FacadePattern.Contracts
{
    public interface ILoan
    {
        bool HasNoBadLoans(ICustomer currentCustomer);
    }
}