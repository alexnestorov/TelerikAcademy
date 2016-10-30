namespace MementoPattern.Contracts
{
    /// <summary>
    /// Defines information for ICaretaker interface.
    /// </summary>
    public interface ICaretaker
    {
        /// <summary>
        /// Returns information for current Memento.
        /// </summary>
        /// <returns>Memento with type <see cref="IMemento"/></returns>
        IMemento GetMemento();

        /// <summary>
        /// Returns information for addin Memento.
        /// </summary>
        /// <param name="memento">Memento with type <see cref="IMemento"</param>
        void Add(IMemento memento);
    }
}
