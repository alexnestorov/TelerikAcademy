using System;
using System.Collections.Generic;
using System.Linq;

using MediatorPattern.Contracts;

namespace MediatorPattern.Models
{
    /// <summary>
    /// Represents implementation of IAirTrafficControl interface.
    /// </summary>
    public class RegionalAirTrafficControl : IAirTrafficControl
    {
        private IList<IAircraft> registeredAircrafts;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionalAirTrafficControl"/> class.
        /// </summary>
        /// <param name="registeredAircrafts">Parameter with type IList<IAircraft> </param>
        public RegionalAirTrafficControl(IList<IAircraft> registeredAircrafts)
        {
            if (registeredAircrafts == null)
            {
                throw new ArgumentNullException("Registered Aircraft can not be null.");
            }

            this.registeredAircrafts = registeredAircrafts;
        }

        /// <summary>
        /// Returns information for registering aircraft.
        /// </summary>
        /// <param name="aircraft">Parameter with type <see cref="IAircraft"/></param>
        public void RegisterAircraft(IAircraft aircraft)
        {
            if (!this.registeredAircrafts.Contains(aircraft))
            {
                this.registeredAircrafts.Add(aircraft);
            }
        }

        /// <summary>
        /// Returns information for sending warning message.
        /// </summary>
        /// <param name="aircraft">Parameter with type <see cref="IAircraft"/></param>
        public void SendWarningMessage(IAircraft aircraft)
        {
            var currentAircrafts = this.registeredAircrafts.Where(x => !x.Equals(aircraft) &&
                             Math.Abs(x.Altitude - aircraft.Altitude) < 1000);

            foreach (var a in currentAircrafts)
            {
                a.ReceiveWarning(aircraft);
                aircraft.Climb(1000);
            }
        }
    }
}
