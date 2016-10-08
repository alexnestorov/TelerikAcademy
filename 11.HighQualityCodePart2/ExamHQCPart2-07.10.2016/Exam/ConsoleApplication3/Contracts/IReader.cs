namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Defines information about application provider.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Returns information for current using provider in API.
        /// </summary>
        /// <returns></returns>
        string Provider();
    }
}
