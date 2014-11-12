namespace StudentsSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using StudentsSystem.Data;

    public class BaseApiController : ApiController
    {
        private IStudentsSystemData data;
        public BaseApiController(IStudentsSystemData dataToUse)
        {
            this.data = dataToUse;
        }

        protected IStudentsSystemData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}