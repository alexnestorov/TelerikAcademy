using MediatorPattern.Abstracts;
using MediatorPattern.Contracts;

namespace MediatorPattern.Models
{
    /// <summary>
    /// Represents information for Airbus380 based on class Aircraft
    /// </summary>
    public class Airbus380 : Aircraft, IAircraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airbus380"/> class.
        /// </summary>
        /// <param name="registrationNumber">Parameter with type string needed for creating instance</param>
        /// <param name="airTrafficControl">Parameter with type IAirTrafficControl interface needed for creating instance</param>
        public Airbus380(string registrationNumber, IAirTrafficControl airTrafficControl)
            : base(registrationNumber, airTrafficControl)
        {
        }
    }
}
