using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TicTacToe.Data;

namespace TicTacToe.Web.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public abstract class BaseApiController : ApiController
    {
        protected ITicTacToeData data;

        protected BaseApiController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}