namespace TestSchool
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseShouldHaveProperName()
        {
            var course = new Course("math");
            Assert.AreEqual("math", course.Name, "Course doesnt have valid name");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseNameCanNotBeNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNameCanNotBeEmpty()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNameCanNotBeWhiteSpace()
        {
            var course = new Course("   ");
        }

        [TestMethod]
        public void CourseStudentsIsNotNull()
        {
            var course = new Course("math");
            Assert.IsFalse(course.Students == null, "Students in course is not initialized");
        }

        [TestMethod]
        public void AddingStudentToCourseIncreazesNumberOfStudents()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.AddStudent(student);

            Assert.IsTrue(course.Students.Count == 1, "Student count is not right");
        }

        [TestMethod]
        public void AddingStudentToCourseAddsHimToTheListOfStudents()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.AddStudent(student);

            Assert.IsTrue(course.Students.Contains(student), "Student is not added in the course");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseCanNotContain30OrMoreStudents()
        {
            var course = new Course("math");
            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseCanNotContainAStudentMoreThanOnce()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void RemovingStudentReducesNumberOfStudentsInCourse()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.IsTrue(course.Students.Count == 0, "Student count when removing is not right");
        }

        [TestMethod]
        public void RemovingStudentRemovesHimFromCourse()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.IsFalse(course.Students.Contains(student), "Student remove is not right");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseCanNotRemoveAStudentThatItDoesntHave()
        {
            var course = new Course("math");
            var student = new Student("Pesho", 12345);

            course.RemoveStudent(student);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)