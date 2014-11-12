namespace StudentsSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentsSystem.Models;

    public class TestDataModel
    {
        public static Func<Test, TestDataModel> FromDataToModel
        {
            get
            {
                return t => new TestDataModel()
                {
                    Course = t.Course.Name
                };
            }
        }

        public static Test FromModelToData(TestDataModel testDataModel, Course course)
        {
            return new Test()
            {
                Course = course
            };
        }

        public string Course { get; set; }
    }
}