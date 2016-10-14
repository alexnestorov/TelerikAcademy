using System.Collections.Generic;

namespace AbstractFactoryPattern.Contracts
{
    /// <summary>
    /// Describes information about creating sport clubs.
    /// </summary>
    public interface ISportFactory
    {
        /// <summary>
        /// Creates new instance for football club.
        /// </summary>
        /// <param name="matches">First name must be a string</param>
        /// <returns>new instance for football club.</returns>
        IFootballClub CreateFootballClub(ICollection<Game> matches);

        /// <summary>
        /// Creates new instance for basketball club.
        /// </summary>
        /// <returns>new instance for basketball club.</returns>
        IBasketballClub CreateBasketballClub();

        /// <summary>
        /// Creates new instance for volleyball club.
        /// </summary>
        /// <returns>new instance for volleyball club.</returns>
        IVolleyballClub CreateVolleyballClub();
    }
}
