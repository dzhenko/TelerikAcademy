namespace Dijkstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    // http://bgcoder.com/Contests/Practice/Index/90#2
    public class FriendsOfPesho
    {
        /// <summary>
        /// Good when no negative weights are present - if so check Bellman Ford
        /// </summary>
        public static void Dijkstra(Dictionary<Node, List<Edge>> graph, Node startNode)
        {
            // setting all nodes dijkstra distance to infinity
            foreach (var nodeEdgesPair in graph)
            {
                nodeEdgesPair.Key.Dijkstra = int.MaxValue;
            }

            // setting the source dijkstra to 0
            startNode.Dijkstra = 0;

            var bag = new OrderedBag<Node>();

            // adding only the source node
            bag.Add(startNode);

            // when this cycle finishesh we will have a graph containing all the minimum distances to each node
            while (bag.Count > 0)
            {
                // this is always the node with minimum dijkstra distance from all nodes
                var min = bag.RemoveFirst();

                // the node is unreachable or we have visited all nodes
                if (min.Dijkstra == int.MaxValue)
                {
                    break;
                }

                // checking the new dijkstra distances to all of the node's neighbours via the connection to them
                foreach (var edge in graph[min])
                {
                    // the distance to the current neighbour can be the weight + the minimum node's dijkstra distance
                    var potentialDistance = min.Dijkstra + edge.Weight;

                    // we found a better way to reach the node
                    if (potentialDistance < edge.ToNode.Dijkstra)
                    {
                        // update the distance
                        edge.ToNode.Dijkstra = potentialDistance;

                        // only now add the node to the bag (so it can be retrieved later)
                        bag.Add(edge.ToNode);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var PointsStreetsHospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var hospitals = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));

            // for every node we keep a list with its neighbours as well as the cost to reach them
            var graph = new Dictionary<Node, List<Edge>>();

            // we need fast access to nodes by index
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

                // adding two way connections (non directed graph)
                graph[dict[connection[0]]].Add(new Edge(dict[connection[1]], connection[2]));
                graph[dict[connection[1]]].Add(new Edge(dict[connection[0]], connection[2]));
            }

            var absoluteMin = int.MaxValue;

            foreach (var hosp in hospitals)
            {
                var startNode = dict[hosp];

                Dijkstra(graph, startNode);

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
}
