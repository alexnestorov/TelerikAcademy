namespace AdapterPattern.Contracts
{
    /// <summary>
    /// Defines information for specific target implementation.
    /// </summary>
    public interface ISpecificTarget
    {
        /// <summary>
        /// Defines information for specific request.
        /// </summary>
        string SpecificRequest();
    }
}