namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaximumStudentsInCourseAllowed = 30;

        private readonly IList<Student> students;
        private string name;

        public Course(string name)
        {
            this.students = new List<Student>();
            this.Name = name;
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name can not be null");
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be white space");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count + 1 == MaximumStudentsInCourseAllowed)
            {
                throw new ArgumentException("The number of students in a course must be below 30");
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException("This student is already in this course");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentException("This student is not in this course");
            }

            this.students.Remove(student);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)