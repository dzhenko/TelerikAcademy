using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class Program
    {
        static void Main()
        {
            int[] problems = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int variety = int.Parse(Console.ReadLine());
            int min = 0;
            int max = 0;
            int absoluteMin = problems.Length;


            for (int i = 1; i < problems.Length; i++)
            {
                if (problems[min] > problems[i])
                {
                    min = i;
                }
                if (problems[max] < problems[i])
                {
                    max = i;
                }
                if (problems[max] - problems[min] >= variety)
                {
                    int one = Math.Min(max, min);
                    int two = Math.Max(max, min);
                    int currAnswer = ((one + 1) / 2) + ((two - one + 1) / 2 + 1);
                    if (absoluteMin > currAnswer)
                    {
                        absoluteMin = currAnswer;
                    }
                }
            }
            Console.WriteLine(absoluteMin);
        }
    }
}
