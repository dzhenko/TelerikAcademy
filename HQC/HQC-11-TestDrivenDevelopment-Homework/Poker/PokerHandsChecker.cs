namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            foreach (var card in hand.Cards)
            {
                if (hand.Cards.Count(x => x.CompareTo(card) == 0) != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.StraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.FourOfKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.FullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.Flush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.Straight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.ThreeOfKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.TwoPairs;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.Pair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Not a valid hand!");
            }

            return this.GetHandType(hand) == HandType.HighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand.Equals(secondHand))
            {
                throw new ArgumentException("Can not compare hands of the same type");
            }

            foreach (var card in firstHand.Cards)
            {
                if (secondHand.Cards.Contains(card))
                {
                    throw new ArgumentException("One card can not be held by two players!");
                }
            }

            var firstHandType = GetHandType(firstHand);
            var secondHandType = GetHandType(secondHand);

            if (firstHandType != secondHandType)
            {
                return ((int)firstHandType).CompareTo((int)secondHandType);
            }

            if (firstHandType == HandType.Pair)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                var comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);

                if (comparisonResult == 0)
                {
                    var firstOtherCards = firstGroupedByFace.Skip(1).Select(g => g.First()).OrderByDescending(c => c.Face).ToArray();
                    var secondOtherCards = secondGroupedByFace.Skip(1).Select(g => g.First()).OrderByDescending(c => c.Face).ToArray();

                    for (int i = 0; i < firstOtherCards.Length; i++)
                    {
                        var comparison = firstOtherCards[i].Face.CompareTo(secondOtherCards[i].Face);
                        if (comparison != 0)
                        {
                            comparisonResult = comparison;
                            break;
                        }
                    }
                }

                return comparisonResult;
            }
            else if (firstHandType == HandType.TwoPairs)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                var firstHandCards = new List<ICard>();
                firstHandCards.Add(firstGroupedByFace[0].First());
                firstHandCards.Add(firstGroupedByFace[1].First());
                firstHandCards = firstHandCards.OrderByDescending(c => c.Face).ToList();
                firstHandCards.Add(firstGroupedByFace[2].First());

                var secondHandCards = new List<ICard>();
                secondHandCards.Add(secondGroupedByFace[0].First());
                secondHandCards.Add(secondGroupedByFace[1].First());
                secondHandCards = secondHandCards.OrderByDescending(c => c.Face).ToList();
                secondHandCards.Add(secondGroupedByFace[2].First());

                var comparisonResult = firstHandCards[0].Face.CompareTo(secondHandCards[0].Face);

                if (comparisonResult == 0)
                {
                    comparisonResult = firstHandCards[1].Face.CompareTo(secondHandCards[1].Face);

                    if (comparisonResult == 0)
                    {
                        comparisonResult = firstHandCards[2].Face.CompareTo(secondHandCards[2].Face);
                    }
                }

                return comparisonResult;
            }
            else if (firstHandType == HandType.FullHouse)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                var comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);
                return comparisonResult;
            }
            else if (firstHandType == HandType.Flush || firstHandType == HandType.HighCard)
            {
                var firstSortedByFace = firstHand.Cards.OrderByDescending(c => c.Face).ToArray();
                var secondSortedByFace = secondHand.Cards.OrderByDescending(c => c.Face).ToArray();

                var comparisonResult = 0;

                for (int i = 0; i < firstSortedByFace.Length; i++)
                {
                    comparisonResult = firstSortedByFace[i].Face.CompareTo(secondSortedByFace[i].Face);
                    if (comparisonResult != 0)
                    {
                        break;
                    }
                }

                return comparisonResult;
            }
            else if (firstHandType == HandType.ThreeOfKind || firstHandType == HandType.FourOfKind)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                var comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);
                return comparisonResult;
            }

            // straight or straightflush
            else
            {
                var firstSortedByFace = firstHand.Cards.OrderByDescending(c => c.Face).ToArray();
                var secondSortedByFace = secondHand.Cards.OrderByDescending(c => c.Face).ToArray();

                var comparisonResult = firstSortedByFace[0].Face.CompareTo(secondSortedByFace[0].Face);
                return comparisonResult;
            }
        }

        private HandType GetHandType(IHand hand)
        {
            var orderedByFace = hand.Cards.GroupBy(card => card.Face)
                                         .OrderByDescending(group => group.Count())
                                         .ToArray();

            // full house or 4 of a kind
            if (orderedByFace.Length == 2)
            {
                if (orderedByFace[0].Count() == 4)
                {
                    return HandType.FourOfKind;
                }
                else
                {
                    return HandType.FullHouse;
                }
            }

            // three of a kind or two pairs
            else if (orderedByFace.Length == 3)
            {
                if (orderedByFace[0].Count() == 3)
                {
                    return HandType.ThreeOfKind;
                }
                else
                {
                    return HandType.TwoPairs;
                }
            }

            else if (orderedByFace.Length == 4)
            {
                return HandType.Pair;
            }

            // if we reached here that means 5 different cards
            var sortedByFace = hand.Cards.ToArray();
            Array.Sort(sortedByFace);

            // ace can begin or end a flush
            var isStraight = sortedByFace[sortedByFace.Length - 1].Face - sortedByFace[0].Face == 4 ||
                              (sortedByFace[sortedByFace.Length - 1].Face == CardFace.Ace &&
                               sortedByFace[sortedByFace.Length - 2].Face == CardFace.Five);

            var isFlush = sortedByFace.All(x => x.Suit == sortedByFace[0].Suit);

            if (isStraight && isFlush)
            {
                return HandType.StraightFlush;
            }
            else if (isFlush)
            {
                return HandType.Flush;
            }
            else if (isStraight)
            {
                return HandType.Straight;
            }
            else
            {
                return HandType.HighCard;
            }
        }
    }
}
