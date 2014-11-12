using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiesLogin
{
    public partial class Private : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                this.Welcome.Text = "Welcome " + Request.Cookies["Username"].Value;
            }
        }
    }
}