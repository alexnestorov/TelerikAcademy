namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Defines information about person first and last name.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Returns each Person First name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Returns each Person last name.
        /// </summary>
        string LastName { get; }
    }
}
