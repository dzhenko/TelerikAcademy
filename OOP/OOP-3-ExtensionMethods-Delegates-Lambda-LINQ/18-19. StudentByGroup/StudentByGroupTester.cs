namespace _18_19.StudentByGroup
{
    using System;
    using System.Linq;

    public class StudentByGroupTester
    {
        public static void Main()
        {
            Student[] students = GenerateStudentArray();

            //Linq
            Console.WriteLine();
            Console.WriteLine("Linq : ");
            Console.WriteLine();

            var orderedStudentsLinq =   from st in students
                                        orderby st.GroupName
                                        select st;

            foreach (var student in orderedStudentsLinq)
            {
                Console.WriteLine(student);
            }
            //extensionMethods
            Console.WriteLine();
            Console.WriteLine("Extension Methods : ");
            Console.WriteLine();

            var orderedStudentsExtension = students.OrderByGroupName();

            foreach (var student in orderedStudentsExtension)
            {
                Console.WriteLine(student);
            }
        }

        public static Student[] GenerateStudentArray()
        {
            string[] names = new string[] { "Ivan", "Ivanka", "Maria", "Gosho", "Bai Kostadin", "Radi", "Mitko", "Joro" };

            string[] groups = new string[] { "Maths", "Biology", "Law", "ComputerScience", "RoketScience" };

            Random rnd = new Random();

            Student[] students = new Student[rnd.Next(20, 31)];

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student(names[rnd.Next(0, names.Length)], groups[rnd.Next(0, groups.Length)]);
            }

            return students;
        }
    }
}
