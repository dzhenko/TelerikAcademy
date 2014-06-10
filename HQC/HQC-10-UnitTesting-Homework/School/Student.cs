namespace School
{
    using System;

    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
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

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < 10000)
                {
                    throw new ArgumentException("ID can not be less than 10000");
                }

                if (value > 99999)
                {
                    throw new ArgumentException("ID can not be more than 99999");
                }

                this.id = value;
            }
        }

        public void JoinCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null");
            }

            course.RemoveStudent(this);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)