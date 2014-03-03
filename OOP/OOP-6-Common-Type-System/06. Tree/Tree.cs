using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Tree
{
    public class Tree<T>
        where T : IComparable
    {
        private Node root;

        public Tree()
        {
            this.root = null;
        }

        private class Node
        {
            public T value { get; set; }
            public Node Parent { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(T nodeValue)
            {
                this.value = nodeValue;
                this.Parent = null;
                this.LeftChild = null;
                this.RightChild = null;
            }
        }


    }
}
