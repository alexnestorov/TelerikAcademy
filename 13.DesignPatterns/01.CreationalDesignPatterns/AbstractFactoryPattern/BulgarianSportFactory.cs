using System.Collections.Generic;

using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// Represents information about creating different type of Sport club.
    /// </summary>
    internal class BulgarianSportFactory : SportFactory
    {
        /// <summary>
        /// Creates different type of interface IBasketballClub
        /// </summary>
        /// <returns>Instance of BasketballClub</returns>
        public override IBasketballClub CreateBasketballClub()
        {
            return new BasketballClub();
        }

        /// <summary>
        /// Creates different type of interface IFootballClub
        /// </summary>
        /// <param name="footballMatches">First name must be a string</param>
        /// <returns>Instance of FootballClub</returns>
        public override IFootballClub CreateFootballClub(ICollection<Game> footballMatches)
        {
            return new FootballClub(footballMatches);
        }

        /// <summary>
        /// Creates different type of interface IVolleyballClub
        /// </summary>
        /// <returns>Instance of VolleyballClub</returns>
        public override IVolleyballClub CreateVolleyballClub()
        {
            return new VolleyballClub();
        }
    }
}
