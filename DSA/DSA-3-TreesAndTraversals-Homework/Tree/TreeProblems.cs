namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TreeProblems
    {
        public static IList<Node<int>> allNodes;
        public static Node<int> root;

        public static void Main()
        {
            allNodes = ReadInput();

            root = FindTheRoot();

            FindAllLeafs();

            FindAllMiddleNodes();

            FindLongestPath();

            FindPathsWithSum(6);

            FindSubTreesWithSum(6);
        }
        private static void PrintFromRoot(Node<int> root, int offset)
        {

            Console.Write(new string('-', offset) + root.Value);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var child in root.Children)
            {
                PrintFromRoot(child, offset + 2);
            }
        }

        private static void FindSubTreesWithSum(int sum)
        {
            // a sub-tree can be any givven node. We need to find the roots of all sub trees with the given sum

            var rootsOfSubtreesWithSum = new List<Node<int>>();

            foreach (var node in allNodes)
            {
                var subtreeSum = GetSumOfSubTreeWithRoot(node);

                if (subtreeSum == sum)
                {
                    rootsOfSubtreesWithSum.Add(node);
                }
            }

            Console.WriteLine("All subtrees that have sum of {0} are: ", sum);
            foreach (var subRoot in rootsOfSubtreesWithSum)
            {
                PrintFromRoot(subRoot, 0);
                Console.WriteLine(new string('-',40));
            }
            Console.WriteLine();
        }

        private static int GetSumOfSubTreeWithRoot(Node<int> node)
        {
            return GetSumFromNode(node);
        }

        private static int GetSumFromNode(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return node.Value;
            }
            else
            {
                return node.Children.Select(GetSumFromNode).Sum() + node.Value;
            }
        }

        private static void FindPathsWithSum(int sum)
        {
            // paths with sum can start from each node
            var pathsWithSum = new List<int[]>();

            foreach (var node in allNodes)
            {
                var pathsFromThisNode = new List<List<int>>();
                var visitedNodes = new bool[allNodes.Count];
                visitedNodes[node.Value] = true;

                GetPathsWithSumFromNode(node, sum, node.Value, new List<int>() { node.Value }, visitedNodes, pathsFromThisNode);

                pathsWithSum.AddRange(pathsFromThisNode.Select(x => x.ToArray()));
            }

            Console.WriteLine("All paths that have sum of {0} are: ", sum);
            Console.WriteLine(string.Join(Environment.NewLine, pathsWithSum.Select(x => string.Join(" -> ", x))));
            Console.WriteLine();
        }

        private static void GetPathsWithSumFromNode(Node<int> node, int sum, int sumSoFar, List<int> pathSoFar, bool[] visitedNodes, List<List<int>> pathsFromThisNode)
        {
            if (sumSoFar == sum)
            {
                pathsFromThisNode.Add(pathSoFar.ToList());
            }

            if (sumSoFar > sum)
            {
                return;
            }

            foreach (var child in node.Children)
            {
                if (!visitedNodes[child.Value])
                {
                    visitedNodes[child.Value] = true;
                    pathSoFar.Add(child.Value);

                    GetPathsWithSumFromNode(child, sum, sumSoFar + child.Value, pathSoFar, visitedNodes, pathsFromThisNode);

                    visitedNodes[child.Value] = false;
                    pathSoFar.Remove(child.Value);
                }
            }

            if (node.Parent != null && !visitedNodes[node.Parent.Value])
            {
                visitedNodes[node.Parent.Value] = true;
                pathSoFar.Add(node.Parent.Value);

                GetPathsWithSumFromNode(node.Parent, sum, sumSoFar + node.Parent.Value, pathSoFar, visitedNodes, pathsFromThisNode);

                visitedNodes[node.Parent.Value] = false;
                pathSoFar.Remove(node.Parent.Value);
            }
        }

        private static void FindLongestPath()
        {
            // the longest path in a tree is always between two leafs
            var leafs = allNodes.Where(x => x.Children.Count == 0);

            var longestPaths = new List<int[]>();

            foreach (var leaf in leafs)
            {
                var paths = new List<List<int>>();
                var visited = new bool[allNodes.Count];
                visited[leaf.Value] = true;

                GetPathsFromNode(leaf, new List<int>() {leaf.Value}, visited, paths);
                
                if (longestPaths.Count > 0 && paths[0].Count > longestPaths[0].Length)
                {
                    longestPaths.Clear();
                }

                if (longestPaths.Count == 0 || paths[0].Count == longestPaths[0].Length)
                {
                    foreach (var path in paths)
                    {
                        longestPaths.Add(path.ToArray());
                    }
                }
            }

            Console.WriteLine("All maximum paths have length of {0} and are: ", longestPaths[0].Length);
            Console.WriteLine(string.Join(Environment.NewLine, longestPaths.Select(x => string.Join(" -> ", x))));
            Console.WriteLine();
        }

        private static void GetPathsFromNode(Node<int> node, List<int> pathSoFar, bool[] visited, List<List<int>> maxPaths)
        {
            if (maxPaths.Count > 0 && pathSoFar.Count > maxPaths[0].Count)
            {
                maxPaths.Clear();
            }

            if (maxPaths.Count == 0 || pathSoFar.Count == maxPaths[0].Count)
            {
                maxPaths.Add(pathSoFar.ToList());
            }

            foreach (var child in node.Children)
            {
                if (!visited[child.Value])
                {
                    visited[child.Value] = true;
                    pathSoFar.Add(child.Value);

                    GetPathsFromNode(child, pathSoFar, visited, maxPaths);

                    visited[child.Value] = false;
                    pathSoFar.Remove(child.Value);
                }
            }

            if (node.Parent != null && !visited[node.Parent.Value])
            {
                visited[node.Parent.Value] = true;
                pathSoFar.Add(node.Parent.Value);

                GetPathsFromNode(node.Parent, pathSoFar, visited, maxPaths);

                visited[node.Parent.Value] = false;
                pathSoFar.Remove(node.Parent.Value);
            }
        }

        private static void FindAllMiddleNodes()
        {
            Console.Write("All middle nodes are: ");

            Console.WriteLine(string.Join(", ", allNodes.Where(x => x.Children.Count > 0 && x.Parent != null).Select(x => x.Value)));
            Console.WriteLine();
        }

        private static void FindAllLeafs()
        {
            Console.Write("All leafs are: ");

            Console.WriteLine(string.Join(", ", allNodes.Where(x => x.Children.Count == 0).Select(x => x.Value)));
            Console.WriteLine();
        }

        private static Node<int> FindTheRoot()
        {
            var allRoots = allNodes.Where(x => x.Parent == null);

            if (allRoots.Count() != 1)
            {
                throw new ArgumentException("There are invalid number of roots in this tree!");
            }

            var theRoot = allRoots.First();

            Console.WriteLine("The root is " + theRoot.ToString());
            Console.WriteLine();

            PrintFromRoot(theRoot, 0);
            Console.WriteLine();

            return theRoot;
        }

        private static IList<Node<int>> ReadInput()
        {
            SetInConsole();

            var nodesCount = int.Parse(Console.ReadLine());

            var allNodesList = new List<Node<int>>(nodesCount);

            // for x nodes we have x - 1 connections
            for (int i = 0; i < nodesCount - 1; i++)
            {
                // read line
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                // get or create parent
                var parentValue = tokens[0];

                var parentNode = allNodesList.FirstOrDefault(x => x.Value == parentValue);

                if (parentNode == null)
                {
                    parentNode = new Node<int>(parentValue);
                    allNodesList.Add(parentNode);
                }

                // get or create child
                var childValue = tokens[1];

                var childNode = allNodesList.FirstOrDefault(x => x.Value == childValue);

                if (childNode == null)
                {
                    childNode = new Node<int>(childValue);
                    allNodesList.Add(childNode);
                }

                // make connection
                parentNode.Children.Add(childNode);

                childNode.Parent = parentNode;
            }

            return allNodesList;
        }

        private static void SetInConsole()
        {
            Console.SetIn(new StringReader(@"7
2 4
3 2
5 0
3 5
5 6
5 1"));
        }
    }
}
