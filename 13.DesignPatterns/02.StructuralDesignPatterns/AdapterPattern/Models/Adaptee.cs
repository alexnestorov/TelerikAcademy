using System;

using AdapterPattern.Contracts;

namespace AdapterPattern.Models
{
    /// <summary>
    /// Implements needed method from ISpecificTarget interface
    /// </summary>
    public class Adaptee : ISpecificTarget
    {
        /// <summary>
        /// Returns information for specific request.
        /// </summary>
        public string SpecificRequest()
        {
            return string.Format("Called SpecificRequest()");
        }
    }
}