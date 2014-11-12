using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersHtmlControls
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Button_ServerClick(object sender, EventArgs e)
        {
            var rnd = new Random();
            try
            {
                this.Result.InnerText = (rnd.Next(int.Parse(this.Val1.Value), int.Parse(this.Val2.Value) + 1)).ToString();
            }
            catch (Exception)
            {
                this.Result.InnerText = "Invalid input!";
            }
        }
    }
}