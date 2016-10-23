using System.Collections.Generic;

using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern
{
    internal abstract class SportFactory : ISportFactory
    {
        public abstract IBasketballClub CreateBasketballClub();

        public abstract IFootballClub CreateFootballClub(ICollection<Game> footballMatches);

        public abstract IVolleyballClub CreateVolleyballClub();
    }
}
