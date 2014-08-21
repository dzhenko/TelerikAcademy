namespace AcademyTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var tasks = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var variety = int.Parse(Console.ReadLine());

            int answer = tasks.Length;

            for (int i = 0; i < tasks.Length-1; i++)
            {
                for (int j = i + 1; j < tasks.Length; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                                        //inclusive 0
                                            //from 0 to i (inclusive i)
                                                            //from i to j, inclusive j
                        int currCount = 1 + (i + 1) / 2 +  (j - i + 1) / 2;
                        answer = Math.Min(answer, currCount);
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
