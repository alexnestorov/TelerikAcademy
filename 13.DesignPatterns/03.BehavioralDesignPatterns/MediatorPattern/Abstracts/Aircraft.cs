using System;

using MediatorPattern.Contracts;

namespace MediatorPattern.Abstracts
{
    /// <summary>
    /// Defines information about IAircraft interface.
    /// </summary>
    public abstract class Aircraft : IAircraft
    {
        private readonly IAirTrafficControl airTrafficControl;
        private int altitude;

        /// <summary>
        /// Initializes a new instance of the <see cref="Aircraft"/> class.
        /// </summary>
        /// <param name="registrationNumber">Must be with value type string"</param>
        /// <param name="airTrafficControl">Parameter with value type IAirTrafficControl</param>
        public Aircraft(string registrationNumber, IAirTrafficControl airTrafficControl)
        {
            if (airTrafficControl == null)
            {
                throw new ArgumentNullException("Air traffic control can not be null");
            }

            this.RegistrationNumber = registrationNumber;
            this.airTrafficControl = airTrafficControl;
            this.airTrafficControl.RegisterAircraft(this);
        }

        /// <summary>
        /// Gets or sets gets information for registration number.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets gets information for altitude.
        /// </summary>
        public int Altitude
        {
            get
            {
                return this.altitude;
            }

            set
            {
                this.altitude = value;
                this.airTrafficControl.SendWarningMessage(this);
            }
        }

        /// <summary>
        /// Returns information for Aircraft climbing.
        /// </summary>
        /// <param name="heightToClimb">Parameter with type Integer needed for method to climb Aircraft object</param>
        public void Climb(int heightToClimb)
        {
            this.Altitude += heightToClimb;
        }

        /// <summary>
        /// Returns information for Aircraft receive warning.
        /// </summary>
        /// <param name="reportingAircraft">Parameter with type IAricraft interface for receiving a warning</param>
        public void ReceiveWarning(IAircraft reportingAircraft)
        {
            Console.WriteLine("ATC: ({0}) - {1} is at your flight altitude!!!", this.RegistrationNumber, reportingAircraft.RegistrationNumber);
        }
    }
}
