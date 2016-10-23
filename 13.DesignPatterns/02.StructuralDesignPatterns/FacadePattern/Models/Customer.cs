using System;

using FacadePattern.Contracts;

namespace FacadePattern.Models
{
    /// <summary>
    /// Defines Customer class
    /// </summary>
    public class Customer : ICustomer
    {
        private string name;

        /// <summary>
        /// Create instance of customer.
        /// </summary>
        /// <param name="name">Must be with type string</param>
        public Customer(string name)
        {
            if (name == null)
            {
                throw new NullReferenceException("Customer name can not be null");
            }

            this.name = name;
        }

        /// <summary>
        /// Gets Customer Name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }
    }
}