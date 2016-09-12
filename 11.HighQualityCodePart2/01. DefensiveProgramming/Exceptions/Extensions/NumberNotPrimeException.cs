using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{
   public class NumberNotPrimeException : Exception
    {
        public NumberNotPrimeException(string msg)
            : base(msg)
        {
        }
    }
}
