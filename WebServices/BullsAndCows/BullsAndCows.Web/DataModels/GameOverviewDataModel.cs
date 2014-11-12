namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using System.ComponentModel.DataAnnotations;

    using BullsAndCows.Models;

    public class GameOverviewDataModel
    {
        public static Expression<Func<Game, GameOverviewDataModel>> FromGame
        {
            get
            {
                return g => new GameOverviewDataModel()
                {
                    Id = g.Id,
                    DateCreated = g.DateCreated,
                    Name = g.Name,
                    GameState = g.GameState.ToString(),
                    Red = g.FirstPlayer.UserName,
                    Blue = g.SecondPlayer == null ? "No blue player yet" : g.SecondPlayer.UserName
                };
            }
        }
 
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }
        
        public string GameState { get; set; }
    }
}