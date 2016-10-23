using System.Collections.Generic;

namespace AbstractFactoryPattern.Contracts
{
    /// <summary>
    /// Describes information for BasketballClub.
    /// </summary>
    public interface IBasketballClub
    {
        /// <summary>
        /// Gets collection of players.
        /// </summary>
        ICollection<Player> Players { get; }
    }
}