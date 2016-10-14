using System.Collections.Generic;

namespace AbstractFactoryPattern.Contracts
{
    /// <summary>
    /// Describes information for football club.
    /// </summary>
    public interface IFootballClub
    {
        /// <summary>
        /// Gets collection of matches.
        /// </summary>
        ICollection<Game> Matches { get; }
    }
}