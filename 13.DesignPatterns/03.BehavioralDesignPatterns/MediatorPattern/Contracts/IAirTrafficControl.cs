namespace MediatorPattern.Contracts
{
    /// <summary>
    /// Defines information for implementing AirTrafficControl.
    /// </summary>
    public interface IAirTrafficControl
    {
        /// <summary>
        /// Returns information for registering an Aircraft.
        /// </summary>
        /// <param name="aircraft">Parameter of current Aircraft to register.</param>
        void RegisterAircraft(IAircraft aircraft);

        /// <summary>
        /// Returns information for sending warning message an Aircraft.
        /// </summary>
        /// <param name="aircraft">Parameter of current Aircraft to send warning message.</param>
        void SendWarningMessage(IAircraft aircraft);
    }
}
