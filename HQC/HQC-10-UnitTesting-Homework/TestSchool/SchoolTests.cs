namespace TestSchool
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void AddingStudentShouldIncreazeNumberOfStudents()
        {
            var school = new School();
            var student = new Student("pesho", 22222);
            school.AddStudent(student);

            Assert.AreEqual(1, school.StudentsCount, "Student adding does not increaze count");
        }

        [TestMethod]
        public void AddingCourseShouldIncreazeNumberOfCourses()
        {
            var school = new School();
            var course = new Course("pesho");
            school.AddCourse(course);

            Assert.AreEqual(1, school.CoursesCount, "Courses adding does not increaze count");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotAddNullStudents()
        {
            var student = new Student("pesho", 22222);
            student.LeaveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotAddDifferentStudentsWithSameId()
        {
            var school = new School();
            var student1 = new Student("pesho", 22222);
            var student2 = new Student("gosho", 22222);

            school.AddStudent(student1);
            school.AddStudent(student2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotAddNullCourse()
        {
            var school = new School();
            school.AddCourse(null);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)