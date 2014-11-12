using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientBrowserIp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(string.Format("Browser: {0}; IP: {1}", Request.Browser.Browser, Request.UserHostAddress.ToString()));
        }
    }
}