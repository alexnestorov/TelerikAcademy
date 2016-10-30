using MediatorPattern.Abstracts;
using MediatorPattern.Contracts;

namespace MediatorPattern.Models
{
    /// <summary>
    /// Represents information for EasyJet based on class Aircraft
    /// </summary>
    public class EasyJet : Aircraft, IAircraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyJet"/> class.
        /// </summary>
        /// <param name="registrationNumber">Parameter with type string needed for creating instance</param>
        /// <param name="airTrafficControl">Parameter with type IAirTrafficControl interface needed for creating instance</param>
        public EasyJet(string registrationNumber, IAirTrafficControl airTrafficControl)
            : base(registrationNumber, airTrafficControl)
        {
        }
    }
}
