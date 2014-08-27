namespace _01.Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children;
        public TreeNode<T> Father;

        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
            this.Father = null;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
