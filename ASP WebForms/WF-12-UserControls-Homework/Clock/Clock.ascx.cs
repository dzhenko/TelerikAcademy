using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clock
{
    public partial class Clock : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TimeZone
        {
            get { return this.TimeZoneValue.Text; }
            set { this.TimeZoneValue.Text = value; }
        }
    }
}