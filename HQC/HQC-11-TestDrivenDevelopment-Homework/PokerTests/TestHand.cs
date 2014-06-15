namespace PokerTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class TestHand
    {
        public IList<ICard> listOfCards;
        [TestInitialize]
        public void GetListWithCards()
        {
            listOfCards = new List<ICard> {
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Hearts),
            };
        }

        [TestMethod]
        public void NormalHandCreation()
        {
            var hand = new Hand(listOfCards);

            Assert.IsFalse(hand == null, "Hand stays null");
        }

        [TestMethod]
        public void NormalHandCardCount()
        {
            var hand = new Hand(listOfCards);

            Assert.AreEqual(5, hand.Cards.Count, "Hand stays null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingHandWithNullCardsThrowsException()
        {
            var hand = new Hand(null);
        }

        [TestMethod]
        public void HandToStringMethodCheck()
        {
            var hand = new Hand(listOfCards);
            var expected = string.Join(", ", listOfCards);

            Assert.AreEqual(expected, hand.ToString(), "Hand stays null");
        }

        [TestMethod]
        public void TestHandEqualsCast()
        {
            var hand = new Hand(listOfCards);

            Assert.IsFalse(hand.Equals(new int[5]), "Hand equals cast not right");
        }
    }
}
