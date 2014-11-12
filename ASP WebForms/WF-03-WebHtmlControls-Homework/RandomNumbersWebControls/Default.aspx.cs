using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersWebControls
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            try
            {
                this.Result.Text = (rnd.Next(int.Parse(this.Val1.Text), int.Parse(this.Val2.Text) + 1)).ToString();
            }
            catch (Exception)
            {
                this.Result.Text = "Invalid input!";
            }
        }
    }
}