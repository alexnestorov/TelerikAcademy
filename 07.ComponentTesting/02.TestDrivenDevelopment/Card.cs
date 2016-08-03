using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var stringResult = string.Format("Face: {0} - {1}, Suit: {2}",
                this.Face,
                (int)this.Face,
                this.Suit);
            return stringResult;
        }
    }
}
