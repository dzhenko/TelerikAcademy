using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiesLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Username", this.Username.Text) { Expires = DateTime.Now.AddMinutes(1) });
            Response.Redirect("Private.aspx", true);
        }
    }
}