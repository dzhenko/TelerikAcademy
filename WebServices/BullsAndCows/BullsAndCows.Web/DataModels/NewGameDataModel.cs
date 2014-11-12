namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BullsAndCows.Models;

    public class NewGameDataModel
    {
        public static Game CreateGameFromModel(NewGameDataModel gameModel, string userId)
        {
            return new Game()
            {
                DateCreated = DateTime.Now,
                FirstPlayerId = userId,
                FirstPlayerNumber = gameModel.Number,
                GameState = GameState.WaitingForOpponent,
                Name = gameModel.Name
            };
        }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }
    }
}