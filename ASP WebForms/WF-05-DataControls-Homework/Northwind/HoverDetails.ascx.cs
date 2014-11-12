namespace Northwind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class HoverDetails : System.Web.UI.UserControl
    {
        public IQueryable<object> ItemsToDisplay { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.ItemsToDisplay != null)
            {
                this.Details.PageIndex = int.Parse(this.HiddenHoveredItemId.Value) - 1;
                if (this.Details.DataSource == null)
                {
                    this.Details.DataSource = this.ItemsToDisplay.ToList();
                    this.DataBind();
                }
            }
        }
    }
}