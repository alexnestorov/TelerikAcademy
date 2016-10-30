namespace MementoPattern.Contracts
{
    /// <summary>
    /// Defines information for IMemento interface.
    /// </summary>
    public interface IMemento
    {
        /// <summary>
        /// Gets information of FirstName
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets information of LastName
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets information of CellPhone
        /// </summary>
        string CellPhone { get; }

        /// <summary>
        /// Gets information of Address
        /// </summary>
        string Address { get; }
    }
}
