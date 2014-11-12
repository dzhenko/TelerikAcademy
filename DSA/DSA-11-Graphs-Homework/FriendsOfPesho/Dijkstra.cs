namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Node : IComparable<Node>
    {
        public Node(int index)
        {
            this.Index = index;
        }
        public int Dijkstra { get; set; }

        public int Index { get; set; }

        public int CompareTo(Node other)
        {
            return this.Dijkstra.CompareTo(other.Dijkstra);
        }
    }

    public class Edge
    {
        public Node ToNode { get; set; }

        public int Weight { get; set; }

        public Edge(Node toNode, int weight)
        {
            this.ToNode = toNode;
            this.Weight = weight;
        }
    }

    public class Dijkstra
    {
        static void Main(string[] args)
        {
            var PointsStreetsHospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var hospitals = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));

            var graph = new Dictionary<Node, List<Edge>>();

            var dict = new Dictionary<int, Node>();

            for (int i = 0; i < PointsStreetsHospitals[1]; i++)
            {
                var connection = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (!dict.ContainsKey(connection[0]))
                {
                    var node = new Node(connection[0]);
                    dict.Add(connection[0], node);
                    graph.Add(node, new List<Edge>());
                }
                if (!dict.ContainsKey(connection[1]))
                {
                    var node = new Node(connection[1]);
                    dict.Add(connection[1], node);
                    graph.Add(node, new List<Edge>());
                }

                graph[dict[connection[0]]].Add(new Edge(dict[connection[1]], connection[2]));
                graph[dict[connection[1]]].Add(new Edge(dict[connection[0]], connection[2]));
            }

            var absoluteMin = int.MaxValue;

            foreach (var hosp in hospitals)
            {
                foreach (var kv in graph)
                {
                    kv.Key.Dijkstra = int.MaxValue;
                }

                var startNode = dict[hosp];
                startNode.Dijkstra = 0;

                var bag = new OrderedBag<Node>();
                bag.Add(startNode);

                while (bag.Count > 0)
                {
                    var min = bag.RemoveFirst();

                    if (min.Dijkstra == int.MaxValue)
                    {
                        break;
                    }

                    foreach (var edge in graph[min])
                    {
                        var pot = min.Dijkstra + edge.Weight;

                        if (pot < edge.ToNode.Dijkstra)
                        {
                            edge.ToNode.Dijkstra = pot;
                            bag.Add(edge.ToNode);
                        }
                    }
                }

                var currentSum = 0;
                foreach (var kv in dict)
                {
                    if (!hospitals.Contains(kv.Key))
                    {
                        currentSum += kv.Value.Dijkstra;
                    }
                }

                if (absoluteMin > currentSum)
                {
                    absoluteMin = currentSum;
                }
            }

            Console.WriteLine(absoluteMin);
        }
    }
}
