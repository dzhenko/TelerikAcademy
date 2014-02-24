namespace _06.AVNTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
using System.Text;

    public class AvlTree<T> : IEnumerable<AVLTreeNode<T>>,ICloneable
        where T:IComparable<T>
    {
        private AVLTreeNode<T> root;

        public AvlTree()
        {
            this.root = null;
        }

        public AVLTreeNode<T> Root { get; private set; }

        public void AddElement(T valueToAdd)
        {
            //root is null the element becomes the root
            if (this.Root == null)
            {
                this.Root = new AVLTreeNode<T>(valueToAdd);
            }
            else
            {
                var currNode = this.Root;

                while (currNode != null)
                {
                    //currNode value is > valueToAdd - we go to left child
                    if (currNode.Value.CompareTo(valueToAdd) > 0)
                    {
                        if (currNode.LeftChild == null)
                        {
                            currNode.LeftChild = new AVLTreeNode<T>(valueToAdd);
                            //TODO: change balance
                            break;
                        }
                        else
                        {
                            currNode = currNode.LeftChild;
                        }
                    }
                    //currNode value is < valueToAdd - we go to right child
                    else if (currNode.Value.CompareTo(valueToAdd) < 0)
                    {
                        if (currNode.RightChild == null)
                        {
                            currNode.RightChild = new AVLTreeNode<T>(valueToAdd);
                            //TODO: change balance
                            break;
                        }
                        else
                        {
                            currNode = currNode.RightChild;
                        }
                    }
                    //value is the same as the node - we add it randomly to the left or right child(depending on valueItSelf)
                    else
                    {
                        //we add it to the right
                        if (valueToAdd.GetHashCode() % 2 == 0)
                        {
                            if (currNode.RightChild == null)
                            {
                                currNode.RightChild = new AVLTreeNode<T>(valueToAdd);
                                //TODO: change balance
                                break;
                            }
                            else
                            {
                                currNode = currNode.RightChild;
                            }
                        }
                        else
                        {
                            if (currNode.LeftChild == null)
                            {
                                currNode.LeftChild = new AVLTreeNode<T>(valueToAdd);
                                //TODO: change balance
                                break;
                            }
                            else
                            {
                                currNode = currNode.LeftChild;
                            }
                        }
                    }
                }
            }


        }

        public AVLTreeNode<T> FindElement(T valueToFind)
        {
            if (this.Root == null)
            {
                throw new ArgumentException("The tree is empty!");
            }

            var currNode = this.Root;

            while (currNode != null)
            {
                if (currNode.Value.CompareTo(valueToFind) > 0)
                {
                    currNode = currNode.LeftChild;
                }
                else if (currNode.Value.CompareTo(valueToFind) < 0)
                {
                    currNode = currNode.RightChild;
                }
                else
                {
                    return currNode;
                }
            }

            return null;
        }

        public void RemoveElement(T valueToRemove)
        {
            if (this.Root == null)
            {
                throw new ArgumentException("The tree is empty!");
            }

            AVLTreeNode<T> nodeToRemove = FindElement(valueToRemove);

            if (nodeToRemove != null)
            {
                if (nodeToRemove.LeftChild == null && nodeToRemove.RightChild == null)
                {
                    nodeToRemove = null;
                }
                else if (nodeToRemove.LeftChild != null && nodeToRemove.RightChild != null)
                {
                    Console.WriteLine("DAMN IT");
                }
                else if (nodeToRemove.RightChild == null)
                {
                    nodeToRemove = nodeToRemove.LeftChild;
                }
                else
                {
                    nodeToRemove = nodeToRemove.RightChild;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            DFSForPrint(this.Root,0,sb);

            sb.Length--;
            sb.Length--;

            return sb.ToString();
        }

        private void DFSForPrint(AVLTreeNode<T> node, int spaces, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            sb.AppendLine(new string(' ', spaces) + node.Value);

            if (node.LeftChild != null)
            {
                DFSForPrint(node.LeftChild, spaces + 4, sb);
            }

            if (node.RightChild != null)
            {
                DFSForPrint(node.RightChild, spaces + 4, sb);
            }
        }

        public IEnumerator<AVLTreeNode<T>> GetEnumerator()
        {
            List<AVLTreeNode<T>> allNodes = new List<AVLTreeNode<T>>();

            Queue<AVLTreeNode<T>> Q = new Queue<AVLTreeNode<T>>();

            Q.Enqueue(this.Root);

            while (Q.Count != 0)
            {
                var currNode = Q.Dequeue();

                allNodes.Add(currNode);

                if (currNode.LeftChild != null)
                {
                    Q.Enqueue(currNode.LeftChild);
                }

                if (currNode.RightChild != null)
                {
                    Q.Enqueue(currNode.RightChild);
                }
            }

            for (int i = 0; i < allNodes.Count; i++)
            {
                yield return allNodes[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            AvlTree<T> treeToReturn = new AvlTree<T>();

            foreach (var node in this)
            {
                treeToReturn.AddElement(node.Value);
            }

            return treeToReturn;
        }
    }
}
