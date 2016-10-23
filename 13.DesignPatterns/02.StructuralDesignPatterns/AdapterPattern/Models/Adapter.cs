using AdapterPattern.Contracts;
using System;

namespace AdapterPattern.Models
{
    public class Adapter : Target, ITarget
    {
        private ISpecificTarget adaptee;

        public Adapter(ISpecificTarget adaptee)
        {
            if (adaptee == null)
            {
                throw new ArgumentNullException("Adaptee can not be null");
            }

            this.adaptee = adaptee;
        }

        public override string Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            return adaptee.SpecificRequest();
        }
    }
}
