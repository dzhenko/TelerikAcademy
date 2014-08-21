using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class MainProgram
{
    public static void Main()
    {
        int lineCount = int.Parse((Console.ReadLine().Split()[1]));

        var hospitals = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));

        var allNodes = new Dictionary<int, Node>();

        for (int i = 0; i < lineCount; i++)
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (!allNodes.ContainsKey(line[0]))
            {
                allNodes.Add(line[0], new Node(line[0]));
            }

            if (!allNodes.ContainsKey(line[1]))
            {
                allNodes.Add(line[1], new Node(line[1]));
            }

            allNodes[line[0]].Connections.Add(new Connection(allNodes[line[1]], line[2]));
            allNodes[line[1]].Connections.Add(new Connection(allNodes[line[0]], line[2]));
        }

        foreach (var hos in hospitals)
        {
            allNodes[hos].IsHospital = true;
        }

        long answer = long.MaxValue;

        foreach (var hosp in hospitals)
        {
            OrderedBag<Node> unvisited = new OrderedBag<Node>();
            foreach (var node in allNodes)
            {
                if (node.Key == hosp)
                {
                    continue;
                }
                node.Value.Djikstra = int.MaxValue;
                unvisited.Add(node.Value);
            }

            allNodes[hosp].Djikstra = 0;
            unvisited.Add(allNodes[hosp]);

            while (unvisited.Count != 0)
            {
                var currNode = unvisited.GetFirst();

                unvisited.RemoveFirst();

                foreach (var con in currNode.Connections)
                {
                    var potential = currNode.Djikstra + con.Weight;

                    if (potential < con.ToNodeID.Djikstra)
                    {
                        con.ToNodeID.Djikstra = potential;
                        unvisited.Add(con.ToNodeID);
                    }
                }
            }

            long curr = allNodes.Sum(x => x.Value.Djikstra);

            foreach (var hos in hospitals)
            {
                curr -= allNodes[hos].Djikstra;
            }

            if (answer > curr)
            {
                answer = curr;
            }
        }

        Console.WriteLine(answer);
    }

    public class Node : IComparable<Node>
    {
        public int ID { get; set; }
        public int Djikstra { get; set; }
        public bool IsHospital { get; set; }

        public List<Connection> Connections { get; set; }

        public Node(int iD)
        {
            this.ID = iD;
            this.Connections = new List<Connection>();
        }

        public int CompareTo(Node other)
        {
            return this.Djikstra.CompareTo(other.Djikstra);
        }

        public override string ToString()
        {
            return this.ID + "->" + this.Djikstra + "km " + this.Connections.Count + " conn";
        }
    }

    public class Connection
    {
        public Node ToNodeID { get; set; }
        public int Weight { get; set; }
        public Connection(Node toNodeID, int weight)
        {
            this.ToNodeID = toNodeID;
            this.Weight = weight;
        }
    }
}