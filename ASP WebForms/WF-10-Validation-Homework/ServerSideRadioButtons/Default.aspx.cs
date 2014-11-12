using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideRadioButtons
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Radios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Radios.SelectedIndex == 0)
            {
                this.MaleOptions.Visible = true;
                this.FemaleOptions.Visible = false;
            }
            else
            {
                this.MaleOptions.Visible = false;
                this.FemaleOptions.Visible = true;
            }
        }
    }
}