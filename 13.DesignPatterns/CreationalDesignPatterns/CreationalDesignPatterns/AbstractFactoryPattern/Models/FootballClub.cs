using System;
using System.Collections.Generic;

using AbstractFactoryPattern.Contracts;

namespace AbstractFactoryPattern
{
    internal class FootballClub : IFootballClub
    {
        public FootballClub(ICollection<Game> matches)
        {
            if (matches == null)
            {
                throw new ArgumentNullException();
            }

            this.Matches = matches;
        }

        public ICollection<Game> Matches { get; }

        public ICollection<Player> Players { get; }
    }
}