namespace _09._16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTest
    {
        public static List<Student> list = new List<Student>(){
                    new Student("Bai", "Ivan", "23361406","0299999999", "ivan@abv.bg", 3,           3, 3, 3, 5, 4, 1),
                    new Student("Az", "Imam", "11111105", "+359212345123", "g@G.G", 2,              1, 1, 1, 1),
                    new Student("Imam", "Samo6", "23361406","+359877333444", "baaaaan@abv.bg", 2,   6, 6, 6, 3),
                    new Student("Kaka", "Minka", "12345608","+359874334144", "gorilaz@gmail.bg", 3, 6, 6, 6, 4, 6, 1),
                    new Student("Bruno", "Mars", "88888844","07333441114", "baven@abv.bg", 2,       2, 2,3,4),
                    new Student("Nooo", "Dont", "14514506","+359211434442", "please@abv.bg", 2,     6, 6, 6, 4, 6, 1),
                    new Student("Kaka", "Minka", "12345608","+359874334442", "gorilaz@gmail.bg", 3, 3, 3, 3, 4, 3, 1)
                };
        public static void Main()
        {
            Task9();
                        
            Task10();
                        
            Task11();
                        
            Task12();
                        
            Task13();
                        
            Task14();
                        
            Task15();
                        
            Task16();
        }

        private static void Task16()
        {
            Console.WriteLine("Task 16:");

            List<Group> groups = new List<Group>()
            {
                new Group(1, "Physics"),
                new Group(2, "Arts"),
                new Group(3, "Mathematics"),
                new Group(4, "Law"),
                new Group(5, "Medicine"),
                new Group(6, "Biology"),
            };

            var StudentsFromGroupMathematics = from student in list
                                               join grp in groups on student.GroupNumber equals grp.GroupNumber
                                               where grp.DepartmentName == "Mathematics"
                                               select student;

            foreach (var student in StudentsFromGroupMathematics)
            {
                Console.WriteLine(student);
            }               
        }

        private static void Task15()
        {
            Console.WriteLine("Task 15:");

            var MarksFromStudentsEnrolledIn2006 = from student in list
                                                  where student.FacultyNumber.EndsWith("06")
                                                  select student.Marks;

            List<int> marks = new List<int>();

            foreach (var mark in MarksFromStudentsEnrolledIn2006)
            {
                marks.AddRange(mark);
            }

            Console.WriteLine(string.Join(", ", marks));
        }

        private static void Task14()
        {
            Console.WriteLine("Task 14:");

            List<Student> studentsFromGroup2 = list.GetListOfStudentsWithNumberOfMarks(2,2);

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task13()
        {
            Console.WriteLine("Task 13:");

            var studentsWithAtLeastOneSix = 
                        from student in list
                        where student.Marks.Contains(6)
                        select new { StudentName = string.Format("{0} {1}", student.FirstName,student.LastName),
                                     Marks = student.Marks };

            foreach (var student in studentsWithAtLeastOneSix)
            {
                Console.WriteLine(student.StudentName + "'s marks: " + string.Join(", ",student.Marks));
            }
        }

        private static void Task12()
        {
            Console.WriteLine("Task 12:");

            var StudentsWithPhonesInSofia = from student in list
                                            where student.Telephone.StartsWith("+3592") || student.Telephone.StartsWith("02")
                                            select student;

            foreach (var student in StudentsWithPhonesInSofia)
            {
                Console.WriteLine(student);
            }

        }

        private static void Task11()
        {
            Console.WriteLine("Task 11:");

            var studentsWithMailInABV = from student in list
                                        where student.Email.Substring(student.Email.LastIndexOf("@")) == "@abv.bg"
                                        select student;

            foreach (var student in studentsWithMailInABV)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task10()
        {
            Console.WriteLine("Task 10:");

            List<Student> studentsFromGroup2 = list.GetListOfStudentsInExactGroup(2);

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine(student);
            }

        }

        private static void Task9()
        {
            Console.WriteLine("Task 9:");
            var groupNumber2Students =
                                        from student in list
                                        where student.GroupNumber == 2
                                        orderby student.FirstName
                                        select student;

            foreach (var student in groupNumber2Students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
