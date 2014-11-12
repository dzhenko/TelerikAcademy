using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesSinglePage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Details_Command(object sender, CommandEventArgs e)
        {
            var id = int.Parse(e.CommandArgument.ToString());
            this.FormView.DataSource = (new NorthwindEntities()).Employees.Where(em => em.EmployeeID == id).ToList();
            this.FormView.DataBind();
        }

        public IQueryable<Employee> AllEmps_GetData()
        {
            return (new NorthwindEntities()).Employees;
        }
    }
}