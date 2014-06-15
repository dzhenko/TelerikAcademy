namespace PokerTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class TestCard
    {
        [TestMethod]
        public void TestCreatingNormalCardFace()
        {
            var card = new Card(CardFace.Ace, CardSuit.Diamonds);

            Assert.AreEqual(true, card.Face == CardFace.Ace, "Card face is not setting right");
        }

        [TestMethod]
        public void TestCreatingNormalCardSuit()
        {
            var card = new Card(CardFace.Ace, CardSuit.Diamonds);

            Assert.AreEqual(true, card.Suit == CardSuit.Diamonds, "Card suit is not setting right");
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);

            var expected = "A" + '\x06';  //♠

            Assert.AreEqual(0, String.Compare(card.ToString(), expected), "Card to string is not setting right");
        }

        [TestMethod]
        public void TestToStringMethod2()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);

            var expected = "A" + '\x05';    //♣  

            Assert.AreEqual(0, String.Compare(card.ToString(), expected), "Card to string is not setting right");
        }

        [TestMethod]
        public void TestToStringMethod3()
        {
            var card = new Card(CardFace.Ace, CardSuit.Diamonds);

            var expected = "A" + '\x04';    //♦

            Assert.AreEqual(0, String.Compare(card.ToString(), expected), "Card to string is not setting right");
        }

        [TestMethod]
        public void TestNotEqualsCast()
        {
            var card = new Card(CardFace.Ace, CardSuit.Diamonds);

            Assert.IsFalse(card.Equals(new int[2]), "Card equals not correct");
        }
    }
}
