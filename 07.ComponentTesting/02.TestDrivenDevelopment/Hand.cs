using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }
            private set
            {
                foreach (var card in value)
                {
                    var counter = value.Count(x => x.Face.Equals(card.Face) &&
                                         x.Suit.Equals(card.Suit));
                    if (counter > 1)
                    {
                        throw new InvalidOperationException("Incorrect hand, can not contain same card more than once");
                    }
                }
                this.cards = value;
            }
        }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            return string.Join(", ", this.Cards);
        }
    }
}
