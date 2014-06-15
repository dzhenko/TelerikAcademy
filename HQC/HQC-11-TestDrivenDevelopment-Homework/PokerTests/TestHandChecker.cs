namespace PokerTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class TestHandChecker
    {
        public PokerHandsChecker checker;

        public Hand straightFlush;
        public Hand fourOfKind;
        public Hand fullHouse;
        public Hand flush;
        public Hand straight;
        public Hand threeOfKind;
        public Hand twoPairs;
        public Hand pair;
        public Hand highCard;

        public Hand onlyFourCardsHand;
        public Hand twoSameCardsHand;

        [TestInitialize]
        public void InitializeChecker()
        {
            checker = new PokerHandsChecker();
            straightFlush = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            fourOfKind = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            fullHouse = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Spades),
            });

            flush = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Seven,CardSuit.Hearts),
            });

            straight = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            threeOfKind = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            twoPairs = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Spades),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            pair = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            highCard = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            });

            onlyFourCardsHand = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
            });

            twoSameCardsHand = new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
            });
        }
        [TestMethod]
        public void CorrectHandTest()
        {
            var valid = checker.IsValidHand(straightFlush);

            Assert.IsTrue(valid, "Valid hand is not considered valid");
        }

        [TestMethod]
        public void LessThan5CardsInHandShouldNotBeValid()
        {
            var valid = checker.IsValidHand(onlyFourCardsHand);

            Assert.IsFalse(valid, "Not valid hand is not considered not valid - we have only 4 cards");
        }

        [TestMethod]
        public void SameCardsInHandShouldNotBeValid()
        {
            var valid = checker.IsValidHand(twoSameCardsHand);

            Assert.IsFalse(valid, "Not valid hand is not considered not valid - we have 2 same cards");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidHighCardShouldThrowException()
        {
            checker.IsHighCard(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidPairShouldThrowException()
        {
            checker.IsOnePair(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidTwoPairsShouldThrowException()
        {
            checker.IsTwoPair(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidThreeOfKindShouldThrowException()
        {
            checker.IsThreeOfAKind(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidStraightShouldThrowException()
        {
            checker.IsStraight(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidFlushShouldThrowException()
        {
            checker.IsFlush(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidFullHouseShouldThrowException()
        {
            checker.IsFullHouse(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidFourOfKindShouldThrowException()
        {
            checker.IsFourOfAKind(onlyFourCardsHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidStraightFlushShouldThrowException()
        {
            checker.IsStraightFlush(onlyFourCardsHand);
        }

        [TestMethod]
        public void HandIsHighCard()
        {
            var result = checker.IsHighCard(highCard);

            Assert.IsTrue(result, "High card is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotHighCard()
        {
            var result = checker.IsHighCard(straightFlush);

            Assert.IsFalse(result, "High card is determined as straight flush");
        }

        [TestMethod]
        public void HandIsPair()
        {
            var result = checker.IsOnePair(pair);

            Assert.IsTrue(result, "Pair is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotPair()
        {
            var result = checker.IsOnePair(straightFlush);

            Assert.IsFalse(result, "Pair is determined as straight flush");
        }

        [TestMethod]
        public void HandIsTwoPairs()
        {
            var result = checker.IsTwoPair(twoPairs);

            Assert.IsTrue(result, "Two Pairs is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotTwoPairs()
        {
            var result = checker.IsTwoPair(straightFlush);

            Assert.IsFalse(result, "Two Pairs is determined as straight flush");
        }

        [TestMethod]
        public void HandIsThreeOfKind()
        {
            var result = checker.IsThreeOfAKind(threeOfKind);

            Assert.IsTrue(result, "Three of a kind is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotThreeOfKind()
        {
            var result = checker.IsThreeOfAKind(straightFlush);

            Assert.IsFalse(result, "Three of a kind is determined as straight flush");
        }

        [TestMethod]
        public void HandIsStraight()
        {
            var result = checker.IsStraight(straight);

            Assert.IsTrue(result, "Straight is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotStraight()
        {
            var result = checker.IsStraight(straightFlush);

            Assert.IsFalse(result, "Straight is determined as straight flush");
        }

        [TestMethod]
        public void HandIsFlush()
        {
            var result = checker.IsFlush(flush);

            Assert.IsTrue(result, "Flush is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotFlush()
        {
            var result = checker.IsFlush(straightFlush);

            Assert.IsFalse(result, "Flush is determined as straight flush");
        }

        [TestMethod]
        public void HandIsFullHouse()
        {
            var result = checker.IsFullHouse(fullHouse);

            Assert.IsTrue(result, "Full house is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotFullHouse()
        {
            var result = checker.IsFullHouse(straightFlush);

            Assert.IsFalse(result, "Full house is determined as straight flush");
        }

        [TestMethod]
        public void HandIsFourOfKind()
        {
            var result = checker.IsFourOfAKind(fourOfKind);

            Assert.IsTrue(result, "Four of a kind is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotFourOfKind()
        {
            var result = checker.IsFourOfAKind(straightFlush);

            Assert.IsFalse(result, "Four of a kind is determined as straight flush");
        }

        [TestMethod]
        public void HandIsStraightFlush()
        {
            var result = checker.IsStraightFlush(straightFlush);

            Assert.IsTrue(result, "Straight flush is not correctly determined");
        }

        [TestMethod]
        public void HandIsNotStraightFlush()
        {
            var result = checker.IsStraightFlush(fourOfKind);

            Assert.IsFalse(result, "Straight flush is determined as four of a kind");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidHandsComparisonSameHands()
        {
            checker.CompareHands(fullHouse,fullHouse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidHandsComparisonHandsWithOverlappingCards()
        {
            checker.CompareHands(fullHouse, flush);
        }

        [TestMethod]
        public void compare2Hands()
        {
            var result = checker.CompareHands(
            new Hand(new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            }), 
            new Hand(new List<ICard> {
                new Card(CardFace.Nine,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Jack,CardSuit.Diamonds),
                new Card(CardFace.Ten,CardSuit.Diamonds),
            }));

            Assert.AreEqual(1, result, "Hand comparison dont work on 2 straight flushes");
        }

        private readonly IHand handWithNoCards = new Hand(new List<ICard>());

        private readonly IHand handWithHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Two, CardSuit.Spades),
        });

        private readonly IHand handWithOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
        });

        private readonly IHand handWithTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Spades),
        });

        private readonly IHand handWithThreeOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Three, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Clubs),
        });

        private readonly IHand handWithStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs)
        });

        private readonly IHand handWithFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Hearts)
        });

        private readonly IHand handWithFullHouse = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Spades),
        });

        private readonly IHand handWithFourOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Diamonds),
            new Card(CardFace.Jack, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Diamonds),
        });

        private readonly IHand handWithStraightFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Clubs)
        });

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnHighCardАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithOnePair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstTwoPair()
        {
            var handWithTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            var actual = this.checker.CompareHands(this.handWithHighCard, handWithTwoPair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithThreeOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithStraight);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstStraightFlush()
        {
            var actual = this.checker.CompareHands(this.handWithHighCard, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstUpperHighCard_1()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(this.handWithHighCard, handWithUpperHighCard);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstUpperHighCard_2()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
            });

            var actual = this.checker.CompareHands(handWithLowerHighCard, handWithUpperHighCard);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstUpperHighCard_3()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(handWithUpperHighCard, handWithLowerHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnHighCardАgainstLowerHighCard()
        {
            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(this.handWithHighCard, handWithLowerHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnOnePairАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnOnePairAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithTwoPair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithThreeOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstStraight()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(handWithOnePair, this.handWithStraight);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithOnePair, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstStraightFlush()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(handWithOnePair, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstUpperOnePair_1()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(this.handWithOnePair, handWithUpperOnePair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstUpperOnePair_2()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            var actual = this.checker.CompareHands(handWithLowerOnePair, handWithUpperOnePair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstUpperOnePair_3()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            });

            var actual = this.checker.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnOnePairАgainstLowerOnePair()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts)
            });

            var actual = this.checker.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnTwoPairАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnTwoPairAgainstHighCard()
        {
            var handWithTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            var actual = this.checker.CompareHands(handWithTwoPair, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairAgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithThreeOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithStraight);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstStraightFlush()
        {
            var actual = this.checker.CompareHands(this.handWithTwoPair, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstUpperTwoPair_1()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(this.handWithTwoPair, handWithUpperTwoPair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstUpperTwoPair_2()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(handWithLowerTwoPair, handWithUpperTwoPair);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstUpperTwoPair_3()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstUpperTwoPair_4()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnTwoPairАgainstLowerTwoPair()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnThreeOfAKindАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindAgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithStraight);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstStraightFlush()
        {
            var handWithThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(handWithThreeOfAKind, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstUpperThreeOfAKind()
        {
            var handWithUpperThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, handWithUpperThreeOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnThreeOfAKindАgainstLowerThreeOfAKind()
        {
            var handWithLowerThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.checker.CompareHands(this.handWithThreeOfAKind, handWithLowerThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnStraightАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnStraightAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightAgainstOnePair()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts)
            });

            var actual = this.checker.CompareHands(handWithStraight, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithStraight, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstStraightFlush()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts)
            });

            var actual = this.checker.CompareHands(handWithStraight, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstUpperStraight()
        {
            var handWithUpperStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var actual = this.checker.CompareHands(this.handWithStraight, handWithUpperStraight);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightАgainstLowerStraight()
        {
            var handWithLowerStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs)
            });

            var actual = this.checker.CompareHands(this.handWithStraight, handWithLowerStraight);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnFlushАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnFlushAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushAgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithStraight);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstStraightFlush()
        {
            var actual = this.checker.CompareHands(this.handWithFlush, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstUpperFlush_1()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(this.handWithFlush, handWithUpperFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstUpperFlush_2()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            });

            var handWithLowerFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(handWithLowerFlush, handWithUpperFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFlushАgainstUpperFlush_3()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            var handWithLowerFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            });

            var actual = this.checker.CompareHands(handWithUpperFlush, handWithLowerFlush);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnFullHouseАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnFullHouseAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseAgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithStraight);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithFlush);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstStraightFlush()
        {
            var actual = this.checker.CompareHands(this.handWithFullHouse, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstUpperFullHouse()
        {
            var handWithUpperFullHouse = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(this.handWithFullHouse, handWithUpperFullHouse);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFullHouseАgainstLowerFullHouse()
        {
            var handWithUpperFullHouse = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(this.handWithFullHouse, handWithUpperFullHouse);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnFourOfAKindАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindAgainstOnePair()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstThreeOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstStraight()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithStraight);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithFlush);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithFullHouse);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstStraightFlush()
        {
            var actual = this.checker.CompareHands(this.handWithFourOfAKind, this.handWithStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstUpperFourOfAKind()
        {
            var handWithUpperFourOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(this.handWithFourOfAKind, handWithUpperFourOfAKind);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnFourOfAKindАgainstLowerFourOfAKind()
        {
            var handWithLowerFourOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var actual = this.checker.CompareHands(this.handWithFourOfAKind, handWithLowerFourOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnStraightFlushАgainstNoCards()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithNoCards);
        }

        [TestMethod]
        
        public void TestOnStraightFlushAgainstHighCard()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithHighCard);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushAgainstOnePair()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
            });

            var actual = this.checker.CompareHands(this.handWithStraightFlush, handWithOnePair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstTwoPair()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithTwoPair);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstThreeOfAKind()
        {
            var handWithStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(handWithStraightFlush, this.handWithThreeOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstStraight()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(this.handWithStraightFlush, handWithStraight);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstFlush()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithFlush);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstFullHouse()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithFullHouse);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstFourOfAKind()
        {
            var actual = this.checker.CompareHands(this.handWithStraightFlush, this.handWithFourOfAKind);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstUpperStraightFlush()
        {
            var handWithUpperStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.checker.CompareHands(this.handWithStraightFlush, handWithUpperStraightFlush);
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        
        public void TestOnStraightFlushАgainstLowerStraightFlush()
        {
            var handWithLowerStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
            });

            var actual = this.checker.CompareHands(this.handWithStraightFlush, handWithLowerStraightFlush);
            Assert.AreEqual(1, actual);
        }
    }
}
