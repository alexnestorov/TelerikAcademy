using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private IList<ICard> handCards;
        private const int ValidHandCardsCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("Hand card is not initialize.");
            }
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            handCards = new List<ICard>();

            foreach (var card in hand.Cards)
            {
                if (!handCards.Any(c => c.ToString().Equals(card.ToString())))
                {
                    handCards.Add(card);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            else if (!IsStraight(hand))
            {
                return false;
            }
            else if (!IsFlush(hand))
            {
                return false;
            }
            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var sortedHand = hand.Cards.OrderBy(x => x.Face).ToList();
            var dictionaryOfEqualCards = new Dictionary<CardFace, int>();
            CountEqualFaceOfCards(sortedHand, dictionaryOfEqualCards);

            bool fourOfAKind = dictionaryOfEqualCards.Any(x => x.Value.Equals(4));
            return fourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            var cardValues = new Dictionary<CardFace, int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (cardValues.ContainsKey(hand.Cards[i].Face))
                {
                    cardValues[hand.Cards[i].Face] += 1;
                }
                else
                {
                    cardValues.Add(hand.Cards[i].Face, 1);
                }
            }

            if (cardValues.Count != 2)
            {
                return false;
            }

            int countOfpairs = cardValues.Values.Count(val => val == 2);
            int countOfthreeKind = cardValues.Values.Count(val => val == 3);

            if (countOfpairs == 1 && countOfthreeKind == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            handCards = new List<ICard>();

            foreach (var card in hand.Cards)
            {
                if (hand.Cards.All(c => c.Suit.Equals(card.Suit)))
                {
                    handCards.Add(card);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderBy(x => x.Face).ToList();
            for (int i = 1; i < sortedHand.Count; i++)
            {
                int previousCardValue = (int)sortedHand[i - 1].Face;
                int currentCardValue = (int)sortedHand[i].Face;
                if (currentCardValue - previousCardValue != 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderBy(x => x.Face).ToList();
            var dictionaryOfEqualCards = new Dictionary<CardFace, int>();
            CountEqualFaceOfCards(sortedHand, dictionaryOfEqualCards);

            bool threeOfAKind = dictionaryOfEqualCards.Any(x => x.Value.Equals(3));
            bool containsPairOfCards = dictionaryOfEqualCards.Any(x => x.Value.Equals(2));
            return threeOfAKind && !containsPairOfCards;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderBy(x => x.Face).ToList();
            var dictionaryOfEqualCards = new Dictionary<CardFace, int>();
            CountEqualFaceOfCards(sortedHand, dictionaryOfEqualCards);

            int pairs = GetEqualityOfCards(dictionaryOfEqualCards, 2);
            bool containsTwoPairsOfCards = pairs.Equals(2);
            return containsTwoPairsOfCards;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ToList();
            var dictionaryOfEqualCards = new Dictionary<CardFace, int>();
            CountEqualFaceOfCards(sortedHand, dictionaryOfEqualCards);
            int pairs = GetEqualityOfCards(dictionaryOfEqualCards, 2);
            bool containsOnePairsOfCards = pairs.Equals(1);
            return containsOnePairsOfCards;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsFourOfAKind(hand) || IsThreeOfAKind(hand) || IsOnePair(hand) ||
                IsTwoPair(hand) || IsFullHouse(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ToList();
            var dictionaryOfEqualCards = new Dictionary<CardFace, int>();
            CountEqualFaceOfCards(sortedHand, dictionaryOfEqualCards);
            int nonePairs = GetEqualityOfCards(dictionaryOfEqualCards, 1);
            bool containsHighCard = nonePairs.Equals(5);
            return containsHighCard;

        }

        private static int GetEqualityOfCards(Dictionary<CardFace, int> dictionaryOfEqualCards, int numberOfEquality)
        {
            int currentNonPairs = 0;
            foreach (var item in dictionaryOfEqualCards)
            {
                if (item.Value.Equals(numberOfEquality))
                {
                    currentNonPairs++;
                }
            }

            return currentNonPairs;
        }

        private static void CountEqualFaceOfCards(List<ICard> sortedHand, Dictionary<CardFace, int> dictionaryOfEqualCards)
        {
            dictionaryOfEqualCards.Add(sortedHand[0].Face, 1);
            for (int i = 1; i < sortedHand.Count; i++)
            {
                int previousCardValue = (int)sortedHand[i - 1].Face;
                int currentCardValue = (int)sortedHand[i].Face;
                if (currentCardValue - previousCardValue == 0)
                {
                    if (dictionaryOfEqualCards.ContainsKey(sortedHand[i].Face))
                    {
                        dictionaryOfEqualCards[sortedHand[i].Face]++;
                    }
                    else
                    {
                        dictionaryOfEqualCards.Add(sortedHand[i].Face, 2);
                    }
                }
                else
                {
                    dictionaryOfEqualCards.Add(sortedHand[i].Face, 1);
                }
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            var firstHandType = this.GetHandType(firstHand);
            var secondHandType = this.GetHandType(secondHand);

            if (firstHandType != secondHandType)
            {
                return firstHandType.CompareTo(secondHandType);
            }
            else
            {
                switch (firstHandType)
                {
                    case HandType.HighCard:
                        return this.CompareHighCardHands(firstHand, secondHand);
                    case HandType.OnePair:
                        return this.CompareOnePairHands(firstHand, secondHand);
                    case HandType.TwoPair:
                        return this.CompareTwoPairHands(firstHand, secondHand);
                    case HandType.ThreeOfAKind:
                        return this.CompareThreeOfAKindHands(firstHand, secondHand);
                    case HandType.Straight:
                    case HandType.StraightFlush:
                        return this.CompareStraightHands(firstHand, secondHand);
                    case HandType.Flush:
                        return this.CompareFlushHands(firstHand, secondHand);
                    case HandType.FullHouse:
                        return this.CompareFullHouseHands(firstHand, secondHand);
                    case HandType.FourOfAKind:
                        return this.CompareFourOfAKindHands(firstHand, secondHand);
                    default:
                        throw new ArgumentException("Invalid hand.");
                }
            }
        }

        private HandType GetHandType(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return HandType.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandType.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandType.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                return HandType.Flush;
            }
            else if (this.IsStraight(hand))
            {
                return HandType.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandType.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandType.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                return HandType.OnePair;
            }
            else if (this.IsHighCard(hand))
            {
                return HandType.HighCard;
            }
            else
            {
                throw new ArgumentException("Invalid hand");
            }
        }

        private int GetHighestCardValue(IHand hand)
        {
            return hand.Cards.Select(value => (int)value.Face).Max();
        }

        private int CompareFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            var firstCardsValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardsValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstFourValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 4).ToArray()[0];
            var secondFourValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 4).ToArray()[0];

            if (firstFourValue != secondFourValue)
            {
                return firstFourValue.CompareTo(secondFourValue);
            }
            else
            {
                var firstKickerValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 1).ToArray()[0];
                var secondKickerValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 1).ToArray()[0];

                return firstKickerValue.CompareTo(secondKickerValue);
            }
        }

        private int CompareFullHouseHands(IHand firstHand, IHand secondHand)
        {
            var firstCardsValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardsValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstThreeValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 3).ToArray()[0];
            var secondThreeValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 3).ToArray()[0];

            if (firstThreeValue != secondThreeValue)
            {
                return firstThreeValue.CompareTo(secondThreeValue);
            }
            else
            {
                var firstTwoValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 2).ToArray()[0];
                var secondTwoValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 2).ToArray()[0];

                return firstTwoValue.CompareTo(secondTwoValue);
            }
        }

        private int CompareFlushHands(IHand firstHand, IHand secondHand)
        {
            var firstSortedValues = firstHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();
            var secondSortedValues = secondHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();

            for (int card = 0; card < PokerHandsChecker.ValidHandCardsCount; card++)
            {
                var compareValue = firstSortedValues[card].CompareTo(secondSortedValues[card]);

                if (compareValue != 0)
                {
                    return compareValue;
                }
            }

            return 0;
        }

        private int CompareStraightHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();

            if (firstCardValues.Contains((int)CardFace.Ace) && firstCardValues.Contains((int)CardFace.Two))
            {
                var aceIndex = Array.IndexOf(firstCardValues, (int)CardFace.Ace);
                firstCardValues[aceIndex] = 1;
            }

            if (secondCardValues.Contains((int)CardFace.Ace) && secondCardValues.Contains((int)CardFace.Two))
            {
                var aceIndex = Array.IndexOf(secondCardValues, (int)CardFace.Ace);
                secondCardValues[aceIndex] = 1;
            }

            return firstCardValues.Max().CompareTo(secondCardValues.Max());
        }

        private int CompareThreeOfAKindHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstThreeValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 3).ToArray()[0];
            var secondThreeValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 3).ToArray()[0];

            if (firstThreeValue != secondThreeValue)
            {
                return firstThreeValue.CompareTo(secondThreeValue);
            }
            else
            {
                var firstHigherKicker = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray().Max();
                var secondHigherKicker = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray().Max();

                if (firstHigherKicker != secondHigherKicker)
                {
                    return firstHigherKicker.CompareTo(secondHigherKicker);
                }
                else
                {
                    var firstLowerKicker = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray().Min();
                    var secondLowerKicker = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray().Min();

                    return firstLowerKicker.CompareTo(secondLowerKicker);
                }
            }
        }

        private int CompareTwoPairHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstHigherPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).Max();
            var secondHigherPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).Max();

            if (firstHigherPairValue != secondHigherPairValue)
            {
                return firstHigherPairValue.CompareTo(secondHigherPairValue);
            }
            else
            {
                var firstLowerPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).Min();
                var secondLowerPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).Min();

                if (firstLowerPairValue != secondLowerPairValue)
                {
                    return firstLowerPairValue.CompareTo(secondLowerPairValue);
                }
                else
                {
                    var firstKickerValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray()[0];
                    var secondKickerValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray()[0];

                    return firstKickerValue.CompareTo(secondKickerValue);
                }
            }
        }

        private int CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).ToArray()[0];
            var secondPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).ToArray()[0];

            if (firstPairValue != secondPairValue)
            {
                return firstPairValue.CompareTo(secondPairValue);
            }
            else
            {
                var firstKickers = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).OrderByDescending(value => value).ToArray();
                var secondKickers = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).OrderByDescending(value => value).ToArray();

                for (int ind = 0; ind < 3; ind++)
                {
                    var compareValue = firstKickers[ind].CompareTo(secondKickers[ind]);

                    if (compareValue != 0)
                    {
                        return compareValue;
                    }
                }

                return 0;
            }
        }

        private int CompareHighCardHands(IHand firstHand, IHand secondHand)
        {
            var firstHighCardValues = firstHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();
            var secondHighCardValues = secondHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();

            for (int card = 0; card < PokerHandsChecker.ValidHandCardsCount; card++)
            {
                var compareValue = firstHighCardValues[card].CompareTo(secondHighCardValues[card]);

                if (compareValue != 0)
                {
                    return compareValue;
                }
            }

            return 0;
        }
    }
}
