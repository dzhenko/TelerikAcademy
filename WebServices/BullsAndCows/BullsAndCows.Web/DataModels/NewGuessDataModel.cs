namespace BullsAndCows.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;
    
    using BullsAndCows.Models;
    using System;

    public class NewGuessDataModel
    {
        public static Guess CreateGuessFromModel(NewGuessDataModel guessModel, string userId, int gameId, int cowsCount, int bullsCount)
        {
            return new Guess()
            {
                BullsCount = bullsCount,
                CowsCount = cowsCount,
                DateMade = DateTime.Now,
                GameId = gameId,
                Number = guessModel.Number,
                UserId = userId
            };
        }

        [Required]
        public string Number { get; set; }
    }
}