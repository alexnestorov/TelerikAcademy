using System;

using FacadePattern.Contracts;

namespace FacadePattern.Models
{
    /// <summary>
    /// Subsystem class.
    /// </summary>
    public class Loan : ILoan
    {
        public bool HasNoBadLoans(ICustomer currentCustomer)
        {
            Console.WriteLine("Check loans for " + currentCustomer.Name);
            return true;
        }
    }
}