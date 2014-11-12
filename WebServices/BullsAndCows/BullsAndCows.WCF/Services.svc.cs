using BullsAndCows.Data;
using BullsAndCows.WCF.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BullsAndCows.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Services.svc or Services.svc.cs at the Solution Explorer and start debugging.
    public class Services : IServices
    {

        private const int UsersPerPage = 10;

        private IBullsAndCowsData data;

        public Services(IBullsAndCowsData data)
        {
            this.data = data;
        }

        public Services()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public UserDetailsDataModel GetById()
        {
            return this.data.Users.All()
                .Where(u => u.Id == "0")
                .Select(UserDetailsDataModel.FromUser)
                .FirstOrDefault();
        }

        public IEnumerable<UserOverviewDataModel> Get()
        {
            return GetByPage();
        }
        public IEnumerable<UserOverviewDataModel> GetByPage()
        {
            int pageNum;
            if (!int.TryParse("0", out pageNum))
            {
                return null;
            }

            return this.data.Users.All()
                .OrderBy(u => u.UserName)
                .Skip(pageNum * UsersPerPage)
                .Take(UsersPerPage)
                .Select(UserOverviewDataModel.FromUser);
        }
    }
}
