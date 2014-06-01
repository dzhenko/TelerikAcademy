namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private const string InvalidNameException = "Name can not be null or empty or white spaces.";
        private const string InvalidStudentNameException = "Name of student can not be null or empty or white spaces.";

        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;

            this.students = new List<string>();

            // no refference to outher list givven this way
            if (students != null)
            {
                foreach (var st in students)
                {
                    this.AddStudent(st);
                }
            }
        }

        public string Name 
        { 
            get 
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameException);
                }

                this.name = value;
            } 
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        public IList<string> GetAllStudents()
        {
            // not returning a refference to the original list or students
            var copyListToReturn = new List<string>();

            foreach (var st in this.students)
            {
                copyListToReturn.Add(string.Copy(st));
            }

            return copyListToReturn;
        }

        // adding students only trough this method
        public void AddStudent(string nameOfStudent)
        {
            if (nameOfStudent == null || string.IsNullOrEmpty(nameOfStudent) || string.IsNullOrWhiteSpace(nameOfStudent))
            {
                throw new ArgumentException(InvalidStudentNameException);
            }

            this.students.Add(nameOfStudent);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Course { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            var allStudents = this.GetAllStudents();

            if (allStudents.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", allStudents) + " }";
            }
        }
    }
}

// ------ StyleCop completed ------
//
// ========== Violation Count: 0 ==========
// 
// :)