//task on link http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%202.zip


namespace _02.ColorfulRabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ColorfulRabbits
    {
        public static void Main()
        {
            int asked = int.Parse(Console.ReadLine());

            var answers = new int[asked];

            for (int i = 0; i < asked; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            int final = 0;

            var dict = answers.GroupBy(x => x).ToDictionary(x => x.Key, z => z.Count());

            foreach (var pair in dict)
            {
                if (pair.Value == 1)
                {
                    final += pair.Key + 1;
                }
                else
                {
                    int times = pair.Value / (pair.Key + 1);
                    if (pair.Value % (pair.Key + 1) != 0)
                    {
                        times++;
                    }

                    final += (times*(pair.Key + 1));
                }
            }

            Console.WriteLine(final);
        }
    }
}
