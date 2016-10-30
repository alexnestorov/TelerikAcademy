namespace MediatorPattern.Contracts
{
    /// <summary>
    /// Represents information needed implementation of IAircraft
    /// </summary>
    public interface IAircraft
    {
        /// <summary>
        /// Gets information for Aircraft altitude in type format Integer.
        /// </summary>
        int Altitude { get; }

        /// <summary>
        /// Gets information for Aircraft registration number in type format String.
        /// </summary>
        string RegistrationNumber { get; }

        /// <summary>
        /// Returns information for Aircraft needed climb.
        /// </summary>
        /// <param name="heightToClimb">Parameter with type value Integer sets the height for climbing</param>
        void Climb(int heightToClimb);

        /// <summary>
        /// Returnts information about receiving warning
        /// </summary>
        /// <param name="reportingAircraft">Parameter of reporting Aircraft for receiving a warning.</param>
        void ReceiveWarning(IAircraft reportingAircraft);
    }
}