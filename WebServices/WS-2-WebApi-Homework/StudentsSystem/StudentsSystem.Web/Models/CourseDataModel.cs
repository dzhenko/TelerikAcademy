using StudentsSystem.Models;
using System;
namespace StudentsSystem.Web.Models
{
    public class CourseDataModel
    {
        public static Func<Course, CourseDataModel> FromDataToModel
        {
            get
            {
                return c => new CourseDataModel()
                {
                    Description = c.Description,
                    Name = c.Name
                };
            }
        }

        public static Course FromModelToData (CourseDataModel courseModel)
        {
            return new Course()
            {
                Name = courseModel.Name,
                Description = courseModel.Description
            };
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}