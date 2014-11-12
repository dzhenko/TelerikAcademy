namespace ATM.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ATM.Transactions;

    [TestClass]
    public class AlLTests
    {
        [TestInitialize]
        public void Seed()
        {
            Transactions.SeedData();
        }

        [TestMethod]
        public void SuccessTest()
        {
            Transactions.WithdrawMoney(1000, "2222222222", "2222");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAValidCardNumberException()
        {
            Transactions.WithdrawMoney(1000, "22212222222", "2222");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotExistingCardNumberException()
        {
            Transactions.WithdrawMoney(1000, "2242222222", "2222");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotAValidCardPinException()
        {
            Transactions.WithdrawMoney(1000, "22212222222", "2422");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotEnoughMoneyException()
        {
            Transactions.WithdrawMoney(100000000, "22212222222", "2222");
        }
    }
}
