using System;
using System.Collections.Generic;

using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern
{
    internal class BasketballClub : IBasketballClub
    {
        public ICollection<Game> Matches
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Player> Players
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}