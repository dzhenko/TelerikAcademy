using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.Name.Text = this.FirstName.Text + " " + this.LastName.Text;
            this.Number.Text = "Faculty number: " + this.FacultyNumber.Text;
            this.UniSpec.Text = "University " + this.University.SelectedValue + " | Speciality " + this.Speciality.SelectedValue;
            var selectedCourses = new List<string>();
            foreach (ListItem item in this.Courses.Items)
            {
                if (item.Selected)
                {
                    selectedCourses.Add(item.Value);
                }
            }
            this.SelectedCourses.Text = "Courses: " + string.Join(", ", selectedCourses);
        }

        public IQueryable<string> GetUniversities()
        {
            return (new[] { "MIT", "CalTech", "NYU", "Boston", "Harvard" }).AsQueryable();
        }

        public IQueryable<string> GetSpecialities()
        {
            return (new[] { "Robotics", "Computer Science", "Physics", "Mathematics", "Biology" }).AsQueryable();
        }

        public IQueryable<string> GetCourses()
        {
            return (new[] { "Math101", "Algorithms101", "Algorithms102", "Physics for dummies", "Bio101" }).AsQueryable();
        }
    }
}