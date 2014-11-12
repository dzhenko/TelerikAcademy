namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GameDetailsDataModel
    {
        public GameDetailsDataModel(Game g, bool firstPlayer)
        {
            this.Id = g.Id;
            this.Name = g.Name;
            this.DateCreated = g.DateCreated;
            this.Red = g.FirstPlayer.UserName;
            this.Blue = g.SecondPlayer.UserName;

            this.YourNumber = firstPlayer ? g.FirstPlayerNumber : g.SecondPlayerNumber;

            this.YourColor = firstPlayer ? "Red" : "Blue";
            this.GameState = g.GameState.ToString();

            var player1Guesses = g.Guesses.AsQueryable()
                .Where(guess => guess.UserId == g.FirstPlayerId)
                .OrderBy(guess => guess.DateMade)
                .Select(GuessDataModel.FromGuess);

            var player2Guesses = g.Guesses.AsQueryable()
                .Where(guess => guess.UserId == g.SecondPlayerId)
                .OrderBy(guess => guess.DateMade)
                .Select(GuessDataModel.FromGuess);

            this.YourGuesses = firstPlayer ? player1Guesses : player2Guesses;
            this.OpponentGuesses = firstPlayer ? player2Guesses : player1Guesses;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public IEnumerable<GuessDataModel> YourGuesses { get; set; }

        public IEnumerable<GuessDataModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }
    }
}