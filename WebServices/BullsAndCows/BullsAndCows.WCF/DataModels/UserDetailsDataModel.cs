namespace BullsAndCows.WCF.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class UserDetailsDataModel
    {
        public static Expression<Func<User, UserDetailsDataModel>> FromUser
        {
            get
            {
                return u => new UserDetailsDataModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Losses = u.Losses,
                    Wins = u.Wins,
                    Rank = u.Wins * 100 + u.Losses * 15
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }

        public int Rank { get; set; }
    }
}