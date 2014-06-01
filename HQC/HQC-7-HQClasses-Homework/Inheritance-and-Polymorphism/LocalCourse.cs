namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        // full constructor chaining :))
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null)
        {
        }

        public LocalCourse(string courseName)
            : this(courseName, null)
        {
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            if (this.Lab != null)
            {
                return "Local" + base.ToString() + "; Lab = " + this.Lab + " }";
            }
            else
            {
                return "Local" + base.ToString() + " }";
            }
        }
    }
}

// ------ StyleCop completed ------
//
// ========== Violation Count: 0 ==========
// 
// :)
