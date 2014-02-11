namespace _06.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
        where T : IComparable<T>
    {
        private T value;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can not be null!");
                }
                this.value = value;
            }
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can not be null!");
                }
                this.leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can not be null!");
                }
                this.rightChild = value;
            }
        }
    }
}
