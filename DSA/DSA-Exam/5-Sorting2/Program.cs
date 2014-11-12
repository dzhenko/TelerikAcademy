using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Sorting2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var startNumber = Console.ReadLine().Replace(" ", "");
            var k = int.Parse(Console.ReadLine());

            var targetNumber = "1";
            for (int i = 2; i <= n; i++)
            {
                targetNumber += i;
            }

            if (targetNumber == startNumber)
            {
                Console.WriteLine(0);
                return;
            }

            var visited = new HashSet<string>();

            var queue = new Queue<string>();
            var steps = -1;

            queue.Enqueue(startNumber);

            while (true)
            {
                steps++;

                var newQueue = new Queue<string>();

                while (queue.Count > 0)
                {
                    var curr = queue.Dequeue();

                    if (!visited.Contains(curr))
                    {
                        visited.Add(curr);

                        var arrayOfCurr = curr.ToCharArray();

                        for (int i = 0; i < n - k + 1; i++)
                        {
                            Array.Reverse(arrayOfCurr, i, k);

                            var newCombo = new string(arrayOfCurr);

                            if (newCombo == targetNumber)
                            {
                                Console.WriteLine(steps + 1);
                                return;
                            }

                            newQueue.Enqueue(newCombo);

                            Array.Reverse(arrayOfCurr, i, k);
                        }
                    }
                }

                queue = newQueue;
                if (queue.Count == 0)
                {
                    if (visited.Contains(targetNumber))
                    {
                        Console.WriteLine(steps);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                    return;
                }
            }
        }
    }
}
