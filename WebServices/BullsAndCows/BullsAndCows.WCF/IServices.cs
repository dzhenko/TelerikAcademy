using BullsAndCows.WCF.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BullsAndCows.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServices" in both code and config file together.
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "users")]
        IEnumerable<UserOverviewDataModel> Get();

        [OperationContract]
        [WebGet(UriTemplate = "users")]
        IEnumerable<UserOverviewDataModel> GetByPage();

        [OperationContract]
        [WebGet(UriTemplate = "users/id")]
        UserDetailsDataModel GetById();
    }
}
