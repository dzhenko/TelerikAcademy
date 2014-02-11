namespace _06.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree(T rootValue)
        {
            this.Root = new TreeNode<T>(rootValue);
        }

        public BinarySearchTree(TreeNode<T> rootNode)
        {
            this.Root = rootNode;
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root can not be null!");
                }
                this.root = value;
            }
        }

        public void AddElement(T elementValue)
        {
            TreeNode<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(elementValue) >= 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new TreeNode<T>(elementValue);
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new TreeNode<T>(elementValue);
                        break;
                    }
                    currentNode = currentNode.RightChild;
                }
            }
        }

        public void DeleteElement(T elementValue)
        {
            TreeNode<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(elementValue) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(elementValue) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else 
                {
                    currentNode = null;
                }
            }
        }

        public TreeNode<T> FindElement(T elementValue)
        {
            TreeNode<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(elementValue) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(elementValue) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }


        public void PrintTree()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(this.Root);

            ulong couner = 0;
            ulong counterchecker = 1;

            while (queue.Count != 0)
            {
                var currNode = queue.Dequeue();

                couner++;

                Console.Write(new string(' ', 10 - (int)counterchecker*2));
                Console.Write(currNode.Value);

                if (couner == counterchecker)
                {
                    Console.WriteLine();
                    couner = 0;
                    counterchecker = (ulong)Math.Pow(2, counterchecker);
                }
                if (currNode.LeftChild != null)
                {
                    queue.Enqueue(currNode.LeftChild);
                }

                if (currNode.RightChild != null)
                {
                    queue.Enqueue(currNode.RightChild);
                }
            }
        }
    }
}
