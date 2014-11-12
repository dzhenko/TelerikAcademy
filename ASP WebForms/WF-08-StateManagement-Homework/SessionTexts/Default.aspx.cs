using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionTexts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AllText"] != null)
            {
                this.AllText.DataSource = (List<string>)Session["AllText"];
                this.DataBind();
            }
        }

        protected void TextEntered_Click(object sender, EventArgs e)
        {
            var text = this.TextBox.Text;
            this.TextResult.Text = text;

            if (Session["AllText"]==null)
            {
                Session["AllText"] = new List<string>();
            }

            var list = (List<string>)Session["AllText"];

            list.Add(text);

            this.AllText.DataSource = list;

            DataBind();
        }
    }
}