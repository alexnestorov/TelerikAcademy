using System;

using FacadePattern.Contracts;

namespace FacadePattern.Models
{
    /// <summary>
    /// Subsystem class.
    /// </summary>
    public class Bank : IBank
    {
        public bool HasSufficientSavings(ICustomer currentCustomer, int amount)
        {
            Console.WriteLine("Check bank for " + currentCustomer.Name);
            return true;
        }
    }
}
