namespace TicTacToe.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToe.GameLogic;

    [TestClass]
    public class GameResultValidatorTests
    {
        private static GameResultValidator validator;

        [TestInitialize]
        public void InitializeObjects()
        {
            validator = new GameResultValidator();
        }

        [TestMethod]
        public void FirstLineWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("XXX--O-O-");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void FirstLineWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("OOOXXOXX-");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void SecondLineWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("OO-XXX---");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void SecondLineWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("XX-OOO-XX");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void ThirdLineWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("OO----XXX");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void ThirdLineWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("XX--XXOOO");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void FirstVerticalWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("XO-XO-X--");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void FirstVerticalWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("OX-OXXO--");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void SecondVerticalWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("OXO-X--X-");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void SecondVerticalWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("XOX-O-XO-");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void ThirdVerticalWith3XShouldBeWonByX()
        {
            var result = validator.GetResult("-OX-OX--X");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void ThirdVerticalWith3OShouldBeWonByO()
        {
            var result = validator.GetResult("XXOXXO--O");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void FirstDiagonalWhenWonByXShouldBeWonByX()
        {
            var result = validator.GetResult("XO--XO--X");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void FirstDiagonalWhenWonByOShouldBeWonByO()
        {
            var result = validator.GetResult("OXXXO---O");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void SecondDiagonalWhenWonByXShouldBeWonByX()
        {
            var result = validator.GetResult("--X-XOXO-");

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void SecondDiagonalWhenWonByOShouldBeWonByO()
        {
            var result = validator.GetResult("XXOXO-O--");

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void GameWhenNotFinishedShouldBeUnfinished2()
        {
            var result = validator.GetResult("---------");

            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void GameWhenNotFinishedShouldBeUnfinished3()
        {
            var result = validator.GetResult("XOXOXOOX-");

            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void GameWhenDRAWShouldBeDraw()
        {
            var result = validator.GetResult("XOXOXOOXO");

            Assert.AreEqual(GameResult.Draw, result);
        }
    }
}
