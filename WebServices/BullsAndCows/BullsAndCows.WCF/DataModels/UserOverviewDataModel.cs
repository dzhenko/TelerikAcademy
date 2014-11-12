namespace BullsAndCows.WCF.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class UserOverviewDataModel
    {
        public static Expression<Func<User, UserOverviewDataModel>> FromUser
        {
            get
            {
                return u => new UserOverviewDataModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }
}