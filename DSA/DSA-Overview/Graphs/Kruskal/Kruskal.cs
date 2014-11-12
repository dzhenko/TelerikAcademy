namespace Kruskal
{
    using System;
    using System.Collections.Generic;

    // find minimum spanning forest - graph can not be entierly connected.
    // works by creating subforests and adding them one to another.
    // uses all edges and always takes the min one

    // TODO: Optimize to use unions
    class Kruskal
    {
        static void Main(string[] args)
        {
            int numberOfNodes = 6;
            List<Edge> edges = new List<Edge>();

            InitializeGraph(edges);

            edges.Sort();

            int[] tree = new int[numberOfNodes + 1]; //we start from 1, not from 0
            List<Edge> mpd = new List<Edge>();
            int treesCount = 1;

            treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

            PrintMinimumSpanningTree(mpd);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++) // TODO: Optimize this - have all children POINT at boss. If boss points at null/himself - ok / else he can point to his new boss.
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }

        private static void PrintMinimumSpanningTree(List<Edge> usedEdges)
        {
            foreach (var edge in usedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            //edges.Add(new Edge(3, 5, 7));
            //edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(5, 6, 12));
        }
    }

    class Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Weight { get; set; }

        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);

            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }
            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", StartNode, EndNode, Weight);
        }
    }
}