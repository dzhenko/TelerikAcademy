using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFord
{
    // http://bgcoder.com/Contests/Practice/Index/64#2
    class GravityTrader
    {
        static void Main()
        {
            // read input data
            int numVertices = int.Parse(Console.ReadLine());

            int numEdges = int.Parse(Console.ReadLine());
            Edge[] edges = new Edge[numEdges];

            for (int i = 0; i < numEdges; i++)
            {
                var tokens = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

                edges[i] = new Edge(tokens[0], tokens[1], tokens[2]);
            }

            // initialize 
            // keep all the found distances
            long[] distances = new long[numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                // initially set to infinity
                distances[i] = int.MaxValue;
            }

            //source
            distances[0] = 0;

            // calculate shortest path with Bellman-Ford
            // relax all the vertices
            for (int v = 0; v < numVertices - 1; v++)
            {
                // try all the edges
                for (int e = 0; e < edges.Length; e++)
                {
                    if (distances[edges[e].EndVertex] > distances[edges[e].StartVertex] + edges[e].Weight)
                    {
                        // we found a shorter way - update the distance to that vertex
                        distances[edges[e].EndVertex] = distances[edges[e].StartVertex] + edges[e].Weight;
                    }
                }
            }

            // check for negative cycles
            bool hasNegativeCycle = false;
            foreach (Edge e in edges)
            {
                if (distances[e.StartVertex] != int.MaxValue)
                {
                    if (distances[e.EndVertex] > distances[e.StartVertex] + e.Weight)
                    {
                        hasNegativeCycle = true;
                        break;
                    }
                }
            }

            // print results
            if (hasNegativeCycle)
            {
                Console.WriteLine("Black hole!");
            }
            else
            {
                for (int i = 0; i < distances.Length; i++)
                {
                    if (distances[i] == int.MaxValue)
                    {
                        Console.WriteLine("Unreachable!");
                    }
                    else
                    {
                        Console.WriteLine(distances[i]);
                    }
                }
            }
        }
    }
    public struct Edge // use struct ?
    {
        public int StartVertex { get; set; }
        public int EndVertex { get; set; }
        public int Weight { get; set; }

        public Edge(int startVertex, int endVertex, int weight) : this()
        {
            this.StartVertex = startVertex;
            this.EndVertex = endVertex;
            this.Weight = weight;
        }
    }
}
