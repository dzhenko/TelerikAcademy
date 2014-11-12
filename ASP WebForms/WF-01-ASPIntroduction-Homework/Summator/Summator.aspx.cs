using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Summator
{
    public partial class Summator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sumBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Result.Text = (int.Parse(this.Val1.Text) + int.Parse(this.Val2.Text)).ToString();
            }
            catch (Exception)
            {
                this.Result.Text = "Invalid input!";
            }
        }
    }
}