namespace MusicStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Data;

    public class BaseApiController : ApiController
    {
        private IMusicStoreData data;

        protected BaseApiController(IMusicStoreData dataToUse)
        {
            this.data = dataToUse;
        }

        protected IMusicStoreData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}