namespace OilerCycle
{
    using System;
    using System.Collections.Generic;

    // a oiler path/cycle visits each edge only once (path) and returns to starting edge (cycle)

    // http://bgcoder.com/Contests/Practice/Index/64#1
    public class ParkWalk
    {
        static void Main()
        {
            Solve(0);
        }

        private static void Solve(int startPosition)
        {
            List<int>[] graph;
            int edgeCount = 0;
            bool answerIsPossible = true;
            Read(out graph, ref edgeCount, ref answerIsPossible);

            if (!answerIsPossible)
            {
                Console.WriteLine("Number of routes: 0");
                return;
            }

            var visited = new bool[graph.Length, graph.Length];

            var counter = 0;

            var path = new List<int>();
            path.Add(startPosition);

            edgeCount = edgeCount / 2;
            DFS(startPosition, ref path, ref graph, ref visited, ref edgeCount, ref counter);

            Console.WriteLine("Number of routes: " + counter);
        }

        private static void Read(out List<int>[] vertexNeighbours, ref int edgesLeft, ref bool isEulerCandidate)
        {
            int n = int.Parse(Console.ReadLine().Trim());
            vertexNeighbours = new List<int>[n];
            string line;
            for (int i = 0; i < n; i++)
            {
                vertexNeighbours[i] = new List<int>();
                line = Console.ReadLine().Trim();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == '1') vertexNeighbours[i].Add(j);
                }
                edgesLeft += vertexNeighbours[i].Count;
                if (vertexNeighbours[i].Count % 2 != 0)
                {
                    isEulerCandidate = false;
                    //return;
                }
            }
        }

        private static void DFS(int node, ref List<int> pathSoFar, ref List<int>[] graph, ref bool[,] visited, ref int edgesLeft, ref int counter)
        {
            if (edgesLeft == 0)
            {
                Console.Write("Route {0}:", ++counter);
                foreach (int vertex in pathSoFar) Console.Write(" {0}", vertex);
                Console.WriteLine();

                return;
            }

            foreach (var neighb in graph[node])
            {
                if (!visited[node, neighb])
                {
                    visited[node, neighb] = true;
                    visited[neighb, node] = true;
                    pathSoFar.Add(neighb);
                    edgesLeft--;

                    DFS(neighb, ref pathSoFar, ref graph, ref visited, ref edgesLeft, ref counter);

                    visited[node, neighb] = false;
                    visited[neighb, node] = false;
                    pathSoFar.RemoveAt(pathSoFar.Count - 1);
                    edgesLeft++;
                }
            }
        }
    }
}
