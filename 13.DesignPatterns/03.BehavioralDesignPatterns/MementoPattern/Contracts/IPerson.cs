namespace MementoPattern.Contracts
{
    /// <summary>
    /// Defines information of IPerson interface.
    /// </summary>
    public interface IPerson
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

        /// <summary>
        /// Returns information for creating Undo
        /// </summary>
        /// <returns>With type <see cref="IMemento"/></returns>
        IMemento CreateUnDo();

        /// <summary>
        /// Returns information for Person information.
        /// </summary>
        /// <returns>With type <see cref="string"/></returns>
        string ShowInfo();
    }
}
