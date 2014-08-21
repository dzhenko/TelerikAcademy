using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.Tree
{
    public class MainProgram
    {
        public static TreeNode<int>[] allNodes;

        public static TreeNode<int> root;
        
        public static void Main()
        {
            //0
            Console.SetIn(new StringReader(@"7
2 4
3 2
5 0
3 5
5 6
5 1
"));

            GenerateAllNodes();

            ReadData();

            //1
            FindRoot();

            //2
            FindAllLeafs();

            //3
            FindAllMiddleNodes();

            //4
            FindLongestPathFromRoot();

            FindLongestPathFirstWay();

            FindLongestPathSecondWay();

            //5
            FindAllSubsetSums(6);

            //6
            FindAllSubTreeSums(6);
        }

        //6
        //each node is a subtree
        private static void FindAllSubTreeSums(int sumToLookFor)
        {
            List<TreeNode<int>> subTreeRootsWithLookedSum = new List<TreeNode<int>>();

            foreach (var node in allNodes)
            {
                Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();

                queue.Enqueue(node);

                int currentSum = 0;

                while (queue.Count != 0)
                {
                    var currNode = queue.Dequeue();

                    currentSum += currNode.Value;

                    if (currentSum > sumToLookFor)
                    {
                        break;
                    }

                    foreach (var childOfCurrNode in currNode.Children)
                    {
                        queue.Enqueue(childOfCurrNode);
                    }
                }

                if (currentSum == sumToLookFor)
                {
                    subTreeRootsWithLookedSum.Add(node);
                }
                
            }

            if (subTreeRootsWithLookedSum.Count == 0)
            {
                Console.WriteLine("There are no roots of SubTrees that have desired sum of {0}: ", sumToLookFor);
            }
            else
            {
                Console.WriteLine("The following roots of SubTrees have desired sum of {0}: ", sumToLookFor);

                Console.WriteLine(string.Join(", ", subTreeRootsWithLookedSum));
            }
        }

        //5
        private static void FindAllSubsetSums(int sumToSearchFor)
        {
            List<string> allStepsForSumS = new List<string>();

            foreach (var node in allNodes)
            {
                bool[] visited = new bool[allNodes.Length];
                List<int> currSteps = new List<int>();
                currSteps.Add(node.Value);
                visited[node.Value] = true;
                FindSubsetSumsFromThisNode(node, node.Value, sumToSearchFor, visited, currSteps, allStepsForSumS);
            }

            Console.WriteLine("All steps to get sum of {0}:",sumToSearchFor);

            foreach (var step in allStepsForSumS)
            {
                Console.WriteLine(step);
            }
        }

        private static void FindSubsetSumsFromThisNode(TreeNode<int> node, int sumSoFar, int sumToSearchFor, bool[] visited, List<int> steps, List<string> allSteps)
        {
            if (sumSoFar == sumToSearchFor)
            {
                allSteps.Add(string.Join(" -> ", steps));
            }

            //if there are negative ints - remove this check
            if (sumSoFar > sumToSearchFor)
            {
                return;
            }

            foreach (var child in node.Children)
            {
                if (!visited[child.Value])
                {
                    visited[child.Value] = true;
                    steps.Add(child.Value);
                    FindSubsetSumsFromThisNode(child, sumSoFar + child.Value, sumToSearchFor, visited,steps,allSteps);
                    steps.Remove(child.Value);
                    visited[child.Value] = false;
                }
            }

            if (node.Father != null && !visited[node.Father.Value])
            {
                visited[node.Father.Value] = true;
                steps.Add(node.Father.Value);
                FindSubsetSumsFromThisNode(node.Father, sumSoFar + node.Father.Value, sumToSearchFor, visited, steps, allSteps);
                steps.Remove(node.Father.Value);
                visited[node.Father.Value] = false;
            }
        }

        //4C - longest path in tree - calculating the longest path in all of the tree starting from each node
        private static void FindLongestPathSecondWay()
        {
            int absoluteLongestPath = 0;

            foreach (var node in allNodes)
            {
                int currLongestPath = 0;
                bool[] visited = new bool[allNodes.Length];
                visited[node.Value] = true;
                FindLongestPathFromThisNode(node,0, ref currLongestPath, visited);
                if (currLongestPath > absoluteLongestPath)
                {
                    absoluteLongestPath = currLongestPath;
                }
            }

            Console.WriteLine("Absolute longest path is: {0}",absoluteLongestPath);
        }

        private static void FindLongestPathFromThisNode(TreeNode<int> node,int pathSoFar, ref int currLongestPath, bool[] visited)
        {
            if (pathSoFar > currLongestPath)
            {
                currLongestPath = pathSoFar;
            }

            foreach (var child in node.Children)
            {
                if (!visited[child.Value])
                {
                    visited[child.Value] = true;
                    FindLongestPathFromThisNode(child, pathSoFar + 1, ref currLongestPath, visited);
                    visited[child.Value] = false;
                }
            }

            if (node.Father != null && !visited[node.Father.Value])
            {
                visited[node.Father.Value] = true;
                FindLongestPathFromThisNode(node.Father, pathSoFar + 1, ref currLongestPath, visited);
                visited[node.Father.Value] = false;
            }
        }

        //4B - longest path in tree - the longest path from Left sibling + the longest path from Right sibling from root
        //or the sum of the max 2 paths starting from root (if the root has 3 childs - and their respective paths are 2 3 4 => 7
        //data validity is not checked! and assuming the root has at least 2 children
        private static void FindLongestPathFirstWay()
        {
            List<int> maxPaths = new List<int>();

            foreach (var rootChild in root.Children)
            {
                int maxPath = 0;
                TraverseTreeForMaxPathFromRoot(rootChild, 0, ref maxPath);

                maxPaths.Add(maxPath + 1);
            }

            maxPaths.Sort();

            int maxPathInTree = maxPaths[maxPaths.Count - 1] + maxPaths[maxPaths.Count - 2];

            Console.WriteLine("Max path in the tree going into two directions from the root is: {0}", maxPathInTree);
        }

        //4A - longest path from root
        private static void FindLongestPathFromRoot()
        {
            int maxPath = 0;
            TraverseTreeForMaxPathFromRoot(root, 0, ref maxPath);
            Console.WriteLine("Longest path from the root is: {0}",maxPath);
        }

        private static void TraverseTreeForMaxPathFromRoot(TreeNode<int> node, int path, ref int maxPath)
        {
            if (path > maxPath)
            {
                maxPath = path;
            }

            foreach (var child in node.Children)
            {
                TraverseTreeForMaxPathFromRoot(child, path + 1, ref maxPath);
            }
        }

        //3
        private static void FindAllMiddleNodes()
        {
            List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();

            foreach (var node in allNodes)
            {
                if (node.Children.Count != 0 && node.Father != null)
                {
                    middleNodes.Add(node);
                }
            }

            Console.WriteLine("Middle nodes are: {0}",string.Join(", ",middleNodes));
        }

        //2
        private static void FindAllLeafs()
        {
            List<TreeNode<int>> leafs = new List<TreeNode<int>>();

            foreach (var node in allNodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            Console.WriteLine("All leafs are: {0}",string.Join(", ",leafs));
        }

        //1
        private static void FindRoot()
        {
            foreach (var node in allNodes)
            {
                if (node.Father == null)
                {
                    root = node;
                }
            }

            Console.WriteLine("The root is {0}",root.Value);
        }

        //0
        private static void GenerateAllNodes()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            allNodes = new TreeNode<int>[numberOfNodes];

            for (int i = 0; i < allNodes.Length; i++)
            {
                allNodes[i] = new TreeNode<int>(i);
            }
        }

        private static void ReadData()
        {
            for (int i = 0; i < allNodes.Length - 1; i++)
            {
                int[] parentAndChild = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int parendIndex = parentAndChild[0];
                int childIndex = parentAndChild[1];

                allNodes[parendIndex].Children.Add(allNodes[childIndex]);
                allNodes[childIndex].Father = allNodes[parendIndex];
            }
        }
    }
}
