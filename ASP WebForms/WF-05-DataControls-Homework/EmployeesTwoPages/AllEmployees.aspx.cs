using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesTwoPages
{
    public partial class AllEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Employee> AllEmps_GetData()
        {
            return (new NorthwindEntities()).Employees;
        }
    }
}