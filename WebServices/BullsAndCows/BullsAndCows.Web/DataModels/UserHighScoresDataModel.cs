namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class UserHighScoresDataModel
    {
        public static Expression<Func<User, UserHighScoresDataModel>> FromUser
        {
            get
            {
                return u => new UserHighScoresDataModel()
                {
                    Username = u.UserName,
                    Rank = u.Wins * 100 + u.Losses * 15
                };
            }
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}