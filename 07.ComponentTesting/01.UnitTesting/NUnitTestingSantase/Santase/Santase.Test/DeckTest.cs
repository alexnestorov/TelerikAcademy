using System;
using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;

namespace Santase.Test
{
    [TestFixture]
    public class DeckTest
    {
        [TestCase]
        public void CreatingACardShouldBeSuccessful()
        {
            var card = new Card(CardSuit.Club, CardType.Jack);

            var cardNumber = (int)card.Suit;

            Assert.Greater(12,cardNumber);
        }
    }
}
