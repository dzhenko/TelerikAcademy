//Write a method that from a given array of students finds all students
//whose first name is before its last name alphabetically. Use LINQ query operators.(task3)

//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.(task4)

//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
//by first name and last name in descending order. Rewrite the same with LINQ.(task5)

namespace Students
{
    using System;
    using System.Linq;

    struct Student
    {
        public string FirstName { get; private set; }
        public string LastName { get;  private set; }
        public int Age { get; private set; }

        public Student(string firstName,string lastname,int age) 
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Age = age;
        }
    }

    class StudentsTesting
    {
        static void Main()
        {
            Student[] students = new Student[] {new Student("Ivan","Ivanov",19) ,
                                                 new Student("Petur", "Stamatov" , 21),
                                                new Student("Petur", "Ivanov" , 17),
                                                 new Student("Iva" ,"Avramova" , 24),
                                                  new Student ("Greta","Petrova" , 26)};
            //task 3
            var FirstNameBeforeLastNameAlphabetically = //thumbs up for the variable name :D
                    from student in students
                    where student.FirstName.CompareTo(student.LastName) < 0
                    select student;

            Console.WriteLine("First Name is before Last Name alphabetically : ");
            foreach (var item in FirstNameBeforeLastNameAlphabetically)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            //task 4
            Console.WriteLine("Students age is between 18 and 24 : ");
            var StudentsWithAgeBetween18and24 =
                    from student in students
                    where student.Age >= 18 && student.Age <= 24
                    select student;

            foreach (var item in StudentsWithAgeBetween18and24)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            //task 5
            Console.WriteLine("Sorted by FirstName and Last Name Lambda : ");
            var SortedStudentsFirstNameLastNameDescendingLambda =
                students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var item in SortedStudentsFirstNameLastNameDescendingLambda)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            Console.WriteLine("Sorted by FirstName and Last Name Linq : ");
            var SortedStudentsFirstNameLastNameDescendingLINQ =
                            from student in students
                            orderby student.FirstName descending, student.LastName descending
                            select student;

            foreach (var item in SortedStudentsFirstNameLastNameDescendingLINQ)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}
