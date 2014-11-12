using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesTwoPages
{
    public partial class DetailsEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request.PathInfo.Substring(1));
            this.Details.DataSource = (new NorthwindEntities()).Employees.Where(em => em.EmployeeID == id).ToList();
            this.Details.DataBind();
        }
    }
}