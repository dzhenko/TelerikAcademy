using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinksMenu
{
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Data != null)
            {
                this.DataList.DataSource = this.Data;
                this.DataList.DataBind();
            }

            if (this.Font != null)
            {
                this.DataList.Font.CopyFrom(this.Font);
            }

            if (this.FontColor != null)
            {
                this.DataList.ForeColor = this.FontColor;
            }
        }

        public IEnumerable<object> Data { get; set; }

        public FontInfo Font { get; set; }

        public Color FontColor { get; set; }
    }
}