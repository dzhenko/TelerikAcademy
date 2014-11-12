namespace StudentsSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentsSystem.Models;

    public class StudentDataModel
    {
        public static Func<Student, StudentDataModel> FromDataToModel
        {
            get
            {
                return s => new StudentDataModel()
                    {
                        Address = s.AdditionalInformation.Address,
                        Email = s.AdditionalInformation.Email,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Level = s.Level,
                        StudentIdentification = s.StudentIdentification,
                    };
            }
        }

        public static Student FromModelToData (StudentDataModel studentModel)
        {
            return new Student()
            {
                AdditionalInformation = new StudentInfo()
                {
                    Address = studentModel.Address,
                    Email = studentModel.Email
                },
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Level = studentModel.Level,
                StudentIdentification = studentModel.StudentIdentification
            };
        }

        public int StudentIdentification { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }

        public string Assistant { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

    }
}
