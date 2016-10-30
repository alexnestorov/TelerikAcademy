using MediatorPattern.Abstracts;
using MediatorPattern.Contracts;

namespace MediatorPattern.Models
{
    /// <summary>
    /// Represents information for Boeing747 based on class Aircraft
    /// </summary>
    public class Boeing747 : Aircraft, IAircraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Boeing747"/> class.
        /// </summary>
        /// <param name="registrationNumber">Parameter with type string needed for creating instance</param>
        /// <param name="airTrafficControl">Parameter with type IAirTrafficControl interface needed for creating instance</param>
        public Boeing747(string registrationNumber, IAirTrafficControl airTrafficControl)
            : base(registrationNumber, airTrafficControl)
        {
        }
    }
}
