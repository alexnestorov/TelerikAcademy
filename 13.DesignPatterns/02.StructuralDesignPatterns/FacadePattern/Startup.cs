using System;
using System.Reflection;

using FacadePattern.Contracts;
using FacadePattern.Models;
using Ninject;

namespace FacadePattern
{
    public class Startup
    {
        /// <summary>
        /// Entry point into console application.
        /// Create facade pattern.
        /// More information you can see in the link below.
        /// http://www.dofactory.com/net/facade-design-pattern
        /// </summary>
        public static void Main()
        {
            {
                // 
                // For creation I am using Ninject IoC Container.
                // More information about it you can see on the link below.
                // https://github.com/ninject/Ninject/blob/master/README.md
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                // Facade
                Mortgage mortgage = kernel.Get<Mortgage>();

                // Evaluate mortgage eligibility for customer
                var customer = kernel.Get<ICustomer>();
                bool eligible = mortgage.IsEligible(customer, 125000);

                Console.WriteLine("\n" + customer.Name +
                    " has been " + (eligible ? "Approved" : "Rejected"));

                // Wait for user
                Console.ReadKey();
            }
        }
    }
}
