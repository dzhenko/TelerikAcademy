using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _2_Labyrinth
{
    class Node : IComparable<Node>
    {
        public int Dijkstra { get; set; }

        public int row { get; set; }

        public int col { get; set; }

        public int level { get; set; }

        public Node(int level, int row, int col)
        {
            this.level = level;
            this.row = row;
            this.col = col;
            this.up = false;
            this.down = false;
        }

        public bool up { get; set; }

        public bool down { get; set; }

        public int CompareTo(Node other)
        {
            return this.Dijkstra.CompareTo(other.Dijkstra);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1} {2} {3}]", this.Dijkstra, this.level, this.row, this.col);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var start = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var lrc = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            var bag = new OrderedBag<Node>();

            var graph = new Node[lrc[0], lrc[1], lrc[2]];

            const int maxDistance = 666666666;
            const int notPassable = 999999999;

            var exits = new HashSet<Tuple<int, int, int>>();

            for (int level = 0; level < lrc[0]; level++)
            {
                for (int row = 0; row < lrc[1]; row++)
                {
                    var line = Console.ReadLine();

                    for (int col = 0; col < lrc[2]; col++)
                    {
                        var node = new Node(level, row, col);
                        if (line[col] == '.')
                        {
                            node.Dijkstra = maxDistance;
                        }
                        else if (line[col] == '#')
                        {
                            node.Dijkstra = notPassable;
                        }
                        else if (line[col] == 'U')
                        {
                            if (level == lrc[0] - 1)
                            {
                                exits.Add(new Tuple<int, int, int>(level, row, col));
                            }
                            node.Dijkstra = maxDistance;
                            node.up = true;
                        }
                        else if (line[col] == 'D')
                        {
                            if (level == 0)
                            {
                                exits.Add(new Tuple<int, int, int>(level, row, col));
                            }
                            node.Dijkstra = maxDistance;
                            node.down = true;
                        }

                        graph[level, row, col] = node;
                    }
                }
            }

            graph[start[0], start[1], start[2]].Dijkstra = 0;
            bag.Add(graph[start[0], start[1], start[2]]);

            while (bag.Count > 0)
            {
                var min = bag.RemoveFirst();

                var neighbours = new List<Node>();

                if (min.col > 0 && graph[min.level, min.row, min.col - 1].Dijkstra != notPassable)
                {
                    neighbours.Add(graph[min.level, min.row, min.col - 1]);
                }
                if (min.col < lrc[2] - 1 && graph[min.level, min.row, min.col + 1].Dijkstra != notPassable)
                {
                    neighbours.Add(graph[min.level, min.row, min.col + 1]);
                }
                if (min.row > 0 && graph[min.level, min.row - 1, min.col].Dijkstra != notPassable)
                {
                    neighbours.Add(graph[min.level, min.row - 1, min.col]);
                }
                if (min.row < lrc[1] - 1 && graph[min.level, min.row + 1, min.col].Dijkstra != notPassable)
                {
                    neighbours.Add(graph[min.level, min.row + 1, min.col]);
                }
                if (graph[min.level, min.row, min.col].up)
                {
                    if (min.level < lrc[0] - 1 && graph[min.level + 1, min.row, min.col].Dijkstra != notPassable)
                    {
                        neighbours.Add(graph[min.level + 1, min.row, min.col]);
                    }
                }
                if (graph[min.level, min.row, min.col].down)
                {
                    if (min.level > 0 && graph[min.level - 1, min.row, min.col].Dijkstra != notPassable)
                    {
                        neighbours.Add(graph[min.level - 1, min.row, min.col]);
                    }
                }

                for (int i = 0; i < neighbours.Count; i++)
                {
                    if (neighbours[i].Dijkstra > min.Dijkstra + 1)
                    {
                        neighbours[i].Dijkstra = min.Dijkstra + 1;
                        bag.Add(neighbours[i]);
                    }
                }
            }

            var answer = int.MaxValue;

            foreach (var exit in exits)
            {
                if (graph[exit.Item1, exit.Item2, exit.Item3].Dijkstra < answer)
                {
                    answer = graph[exit.Item1, exit.Item2, exit.Item3].Dijkstra;
                }
            }

            Console.WriteLine(answer + 1);
        }
    }
}
