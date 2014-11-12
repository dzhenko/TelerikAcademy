using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Northwind
{
    public partial class Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.HoverDetails.ItemsToDisplay = (new NorthwindEntities()).Employees;
        }
    }
}