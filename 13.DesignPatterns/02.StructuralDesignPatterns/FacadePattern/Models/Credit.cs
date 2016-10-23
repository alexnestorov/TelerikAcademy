using System;

using FacadePattern.Contracts;

namespace FacadePattern.Models
{
    /// <summary>
    /// Subsystem class.
    /// </summary>
    public class Credit : ICredit
    {
        public bool HasGoodCredit(ICustomer currentCustomer)
        {
            Console.WriteLine("Check credit for " + currentCustomer.Name);
            return true;
        }
    }
}