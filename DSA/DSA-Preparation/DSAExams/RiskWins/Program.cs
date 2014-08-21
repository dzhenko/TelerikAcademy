namespace RiskWins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int source = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());

            int forbidenCount = int.Parse(Console.ReadLine());

            HashSet<int> forbiden = new HashSet<int>();

            for (int i = 0; i < forbidenCount; i++)
            {
                forbiden.Add(int.Parse(Console.ReadLine()));
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int,int>(source,0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Item1 == target)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                for (int i = 0; i < 5; i++)
                {
                    var candidate1 = current.Item1;
                    var candidate2 = current.Item1;

                    if ((current.Item1 / GetTenPowers(i)) % 10 == 0)
                    {
                        candidate1 = current.Item1 + GetTenPowers(i);
                        candidate2 = current.Item1 + 9*GetTenPowers(i);
                    }
                    else if ((current.Item1 / GetTenPowers(i)) % 10 == 9)
                    {
                        candidate2 = current.Item1 - GetTenPowers(i);
                        candidate1 = current.Item1 - 9*GetTenPowers(i);
                    }
                    else
                    {
                        candidate1 = current.Item1 + GetTenPowers(i);
                        candidate2 = current.Item1 - GetTenPowers(i);
                    }

                    if (!forbiden.Contains(candidate1))
                    {
                        queue.Enqueue(new Tuple<int, int>(candidate1, current.Item2 + 1));
                        forbiden.Add(candidate1);
                    }

                    if (!forbiden.Contains(candidate2))
                    {
                        queue.Enqueue(new Tuple<int, int>(candidate2, current.Item2 + 1));
                        forbiden.Add(candidate2);
                    }
                }
            }

            Console.WriteLine(-1);
        }

        static int GetTenPowers(int power)
        {
            if (power == 0)
            {
                return 1;
            }
            if (power == 1)
            {
                return 10;
            }
            if (power == 2)
            {
                return 100;
            }
            if (power == 3)
            {
                return 1000;
            }
            else
            {
                return 10000;
            }
        }
    }
}
