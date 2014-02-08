using System;

class StudentTesting
{
    static void Main()
    {
        Student ivan = new Student("Ivan", "Dimitrov", "Ivanov", "sofia", 8888444411, "+359877353443", "ivan@abv.bg",
                                    "politicalstudies", Speciality.Law, Faculty.LawFaculty, University.SU);

        Console.WriteLine(ivan);
    }
}

