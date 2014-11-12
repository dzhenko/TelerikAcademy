namespace HamiltonCycle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // a hamilton path/cycle visits each vertex only once (path) and returns to starting vertex (cycle)

    // http://bgcoder.com/Contests/Practice/Index/64#0
    public class HungryTom
    {
        static List<int>[] graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];

            for (int i = 0; i < graph.Length; i++)
			{
			    graph[i] = new List<int>();
			}

            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph[tokens[0]].Add(tokens[1]);

                graph[tokens[1]].Add(tokens[0]);
            }

            foreach (var door in graph[1])
            {
                var used = new bool[graph.Length];
                used[door] = true;
                DFS(door, used, new List<int>() { door });
            }

            if (answers.Count == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(answers.Count);

                foreach (var answer in answers)
                {
                    Console.WriteLine("1 {0} 1", string.Join(" ", answer));
                }
            }
        }

        static SortedSet<int[]> answers = new SortedSet<int[]>(new Compararerator());

        static void DFS(int index, bool[] used, List<int> steps)
        {
            if (steps.Count == used.Length - 2 && graph[index].Contains(1))
            {
                answers.Add(steps.ToArray());
                return;
            }

            foreach (var door in graph[index])
            {
                if (!used[door] && door != 1)
                {
                    used[door] = true;
                    steps.Add(door);

                    DFS(door, used, steps);

                    used[door] = false;
                    steps.Remove(door);
                }
            }
        }
    }

    public class Compararerator : IComparer<int[]>
    {

        public int Compare(int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return x[i].CompareTo(y[i]);
                }
            }

            return 0;
        }
    }
}
