using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _4_Towns
{
    class Program2
    {
        static Dictionary<string, Node> graph = new Dictionary<string, Node>();

        static void Main(string[] args)
        {
            var allTownsCount = int.Parse(Console.ReadLine());

            var nodeArray = new Node[allTownsCount];
            
            var positiveGraph = new Dictionary<Node, SortedSet<Node>>();
            var negativeGraph = new Dictionary<Node, SortedSet<Node>>();

            for (int i = 0; i < allTownsCount; i++)
            {
                var tokens = Console.ReadLine().Split();

                var node = new Node(tokens[1], int.Parse(tokens[0]), i);

                nodeArray[i] = node;

                graph.Add(tokens[1], node);

                if (!positiveGraph.ContainsKey(node))
                {
                    positiveGraph.Add(node, new SortedSet<Node>());
                }

                if (!negativeGraph.ContainsKey(node))
                {
                    negativeGraph.Add(node, new SortedSet<Node>());
                }

                for (int j = 0; j < i; j++)
                {
                    if (node.Population < nodeArray[j].Population)
                    {
                        nodeArray[j].GoTo.Add(node);

                        negativeGraph[nodeArray[j]].Add(node);
                    }

                    if (node.Population > nodeArray[j].Population)
                    {
                        node.ComeFrom.Add(nodeArray[j]);

                        positiveGraph[nodeArray[j]].Add(node);
                    }
                }
            }

            // checks
            if (allTownsCount == 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (allTownsCount == 2)
            {
                if (nodeArray[0].Population != nodeArray[1].Population)
                {
                    Console.WriteLine(2);
                }
                else
                {
                    Console.WriteLine(1);
                }
                return;
            }

            var sortedList = new List<Node>();

            var noIncoming = new List<Node>();
            noIncoming.Add(nodeArray[0]);

            while (noIncoming.Count > 0)
            {
                var node = noIncoming[noIncoming.Count - 1];
                noIncoming.RemoveAt(noIncoming.Count - 1);

                sortedList.Add(node);

                foreach (var kv in positiveGraph[node])
                {

                }
            }
        }

        
    }

    public struct Node : IComparable<Node>
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public int Index { get; set; }

        public int DijkstraIncreazing { get; set; }

        public int DijkstraDecreazing { get; set; }

        public HashSet<Node> ComeFrom { get; set; }

        public HashSet<Node> GoTo { get; set; }

        public Node(string name, int population, int index) : this()
        {
            this.Name = name;
            this.Population = population;
            this.Index = index;

            this.ComeFrom = new HashSet<Node>();
            this.GoTo = new HashSet<Node>();
        }

        public int CompareTo(Node other)
        {
            return this.Index.CompareTo(other.Index);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}] [{2}]", this.Name, string.Join(", ", this.ComeFrom.Select(b => b.Name)), string.Join(", ", this.GoTo.Select(a => a.Name)));
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Node)obj).Name;
        }
    }
}
