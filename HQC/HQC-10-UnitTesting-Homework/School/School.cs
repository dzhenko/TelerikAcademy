namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly IList<Student> students;
        private readonly IList<Course> courses;

        public School()
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
        }

        public int StudentsCount
        {
            get
            {
                return this.students.Count;
            }
        }

        public int CoursesCount
        {
            get
            {
                return this.courses.Count;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }

            foreach (var st in this.students)
            {
                if (st.Id == student.Id)
                {
                    throw new ArgumentException("You can not add more one student with the same ID");
                }
            }

            this.students.Add(student);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }

            this.courses.Add(course);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)