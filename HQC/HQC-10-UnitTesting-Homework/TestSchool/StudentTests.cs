namespace TestSchool
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentShouldHaveNameThatCtorSetHim()
        {
            var student = new Student("john", 22222);
            Assert.AreEqual("john", student.Name, "Student name is not valid");
        }

        [TestMethod]
        public void StudentShouldHaveIdThatCtorSetHim()
        {
            var student = new Student("john", 22222);
            Assert.AreEqual(22222, student.Id, "Student id is not valid");
        }

        [TestMethod]
        public void MaximumStudentIdSet()
        {
            var student = new Student("john", 99999);
            Assert.AreEqual(99999, student.Id, "Student Id is not max");
        }

        [TestMethod]
        public void MinimumStudentIdSet()
        {
            var student = new Student("john", 10000);
            Assert.AreEqual(10000, student.Id, "Student Id is not min");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldNotAcceptNullName()
        {
            var student = new Student(null, 22222);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldNotAcceptEmptyName()
        {
            var student = new Student(string.Empty, 22222);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldNotAcceptWhiteSpaceName()
        {
            var student = new Student("   ", 22222);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldHaveIdLessThan10000()
        {
            var student = new Student("john", 555);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldHaveIdMoreThan99999()
        {
            var student = new Student("john", 100005);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentCanNotJoinNullCourse()
        {
            var student = new Student("pesho", 22222);
            student.JoinCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentCanNotLeaveNullCourse()
        {
            var student = new Student("pesho", 22222);
            student.LeaveCourse(null);
        }

        [TestMethod]
        public void StudentProperlyJoinsCourse()
        {
            var student = new Student("pesho", 22222);
            var course = new Course("math");
            student.JoinCourse(course);

            Assert.IsTrue(course.Students.Contains(student), "Student is not added to course");
        }

        [TestMethod]
        public void StudentProperlyLeavesCourse()
        {
            var student = new Student("pesho", 22222);
            var course = new Course("math");
            student.JoinCourse(course);
            student.LeaveCourse(course);

            Assert.IsFalse(course.Students.Contains(student), "Student is still in the course");
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)