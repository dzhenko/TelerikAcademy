using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HumanTesting
{
    public static Random mainRND = new Random();

    public static string GetRandomName()
    {
        StringBuilder name = new StringBuilder();
        name.Append((char)mainRND.Next(65, 91));
        for (int i = 0; i < mainRND.Next(4,10); i++)
        {
            name.Append((char)mainRND.Next(97, 123));
        }

        return name.ToString();
    }

    public static void Main()
    {
        List<Student> students = new List<Student>();
        List<Worker> workers = new List<Worker>();

        for (int i = 0; i < 10; i++)
        {
            students.Add(new Student(GetRandomName(), GetRandomName(), mainRND.Next(1, 7)));
            workers.Add(new Worker(GetRandomName(), GetRandomName(),(double)mainRND.Next(6,9),(double)mainRND.Next(40,121)));
        }

        var sortedByGradeAscendingStudents = students.OrderBy(x => x.Grade);
        Console.WriteLine("Ordered By grade Students (Thumbs up for the names)");
        foreach (var s in sortedByGradeAscendingStudents)
        {
            Console.WriteLine(s + " ----> " + s.Grade);
        }


        var sortedByMoneyPerHourWorkers =
                    from w in workers
                    orderby w.MoneyPerHour() descending
                    select w;
        Console.WriteLine("Ordered By moneyPerHour workers - descending");
        foreach (var w in sortedByMoneyPerHourWorkers)
        {
            Console.WriteLine(w + " ----> " + w.MoneyPerHour());
        }

        List<Human> allHumans = new List<Human>();
        allHumans.AddRange(sortedByGradeAscendingStudents);
        allHumans.AddRange(sortedByMoneyPerHourWorkers);
        Console.WriteLine("All humans--------------");
        foreach (var h in allHumans)
        {
            Console.WriteLine(h);
        }

        var sortedAllHumans =
                    from h in allHumans
                    orderby h.FirstName, h.LastName
                    select h;
        Console.WriteLine("All sorted humans----------------");
        foreach (var h in sortedAllHumans)
        {
            Console.WriteLine(h);
        }
    }
}

