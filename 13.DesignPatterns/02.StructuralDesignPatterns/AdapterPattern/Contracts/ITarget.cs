namespace AdapterPattern.Contracts
{
    /// <summary>
    /// Defines information for requests.
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// Returns information for ordinary request.
        /// </summary>
        string Request();
    }
}