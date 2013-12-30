using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static Dictionary<string, int> rankings = new Dictionary<string, int>();

    public class Employee
    {
        public string firstName;
        public string lastName;
        public int positionRank;

        public Employee(string FirstName,string LastName,string Position)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.positionRank = rankings[Position];
        }
    }

    static void Main()
    {
        List<Employee> allEmps = new List<Employee>();

        int positonsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < positonsCount; i++)
        {
            string[] currPosition = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            if (!rankings.ContainsKey(currPosition[0]))
            {
                rankings.Add(currPosition[0], int.Parse(currPosition[1]));
            }
        }

        int empsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < empsCount; i++)
        {
            string[] combo = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string[] names = combo[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            allEmps.Add(new Employee(names[0].Trim(), names[1].Trim(), combo[1]));
        }

        var ordered = allEmps.OrderByDescending(x => x.positionRank).ThenBy(x => x.lastName).ThenBy(x => x.firstName);
        foreach (var item in ordered)
        {
            Console.WriteLine("{0} {1}",item.firstName,item.lastName);
        }
    }
}

