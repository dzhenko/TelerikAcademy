using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _3_FriendsInNeed
{
    class Node : IComparable<Node>
    {
        public int value { get; set; }

        public Node(int value)
        {
            this.value = value;
            this.connections = new Dictionary<int, int>();
        }

        public Dictionary<int, int> connections { get; set; }

        public int diikstra { get; set; }

        public int CompareTo(Node other)
        {
            return this.diikstra.CompareTo(other.diikstra);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.value, this.diikstra);
        }
    }

    class Program
    {
        static void Main()
        {
            var nmh = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            var hospitalsString = Console.ReadLine().Split();

            var hospitals = new HashSet<int>();

            foreach (var hospStr in hospitalsString)
            {
                hospitals.Add(int.Parse(hospStr));
            }

            var graph = new Dictionary<int, Node>();

            var line = new string[2];
            var from = 0;
            var to = 0;
            var dist = 0;

            var maxDistance = 99999999;

            for (int i = 0; i < nmh[1]; i++)
            {
                line = Console.ReadLine().Split();
                from = int.Parse(line[0]);
                to = int.Parse(line[1]);
                dist = int.Parse(line[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new Node(from));
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new Node(to));
                }

                graph[from].connections.Add(to, dist);
                graph[to].connections.Add(from, dist);
            }

            long answer = long.MaxValue;

            foreach (var hosp in hospitals)
            {
                var bag = new OrderedBag<Node>();

                foreach (var kv in graph)
                {
                    graph[kv.Key].diikstra = maxDistance;
                    bag.Add(graph[kv.Key]);
                }
                
                graph[hosp].diikstra = 0;

                while (bag.Count > 0)
                {
                    var min = bag.GetFirst();

                    foreach (var kv in min.connections)
                    {
                        var potDistance = min.diikstra + kv.Value;
                        if (potDistance < graph[kv.Key].diikstra)
                        {
                            graph[kv.Key].diikstra = potDistance;
                            bag.Add(graph[kv.Key]);
                        }
                    }

                    bag.RemoveFirst();
                }

                long currentSum = 0;
                foreach (var kv in graph)
                {
                    if (!hospitals.Contains(kv.Key))
                    {
                        currentSum += graph[kv.Key].diikstra;
                    }
                }

                if (answer > currentSum)
                {
                    answer = currentSum;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
