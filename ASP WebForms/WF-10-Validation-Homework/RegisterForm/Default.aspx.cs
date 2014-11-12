using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (IsPostBack && Page.IsValid)
            {
                this.LabelMessage.Text = "Page is valid!";
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelMessage.Text = "The page is valid!";
            }
            this.LabelMessage.Visible = Page.IsValid;
        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = this.RequiredTickValidator.Checked;
        }
    }
}