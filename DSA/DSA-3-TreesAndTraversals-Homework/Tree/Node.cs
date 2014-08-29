namespace Tree
{
    using System.Collections.Generic;

    public class Node<T>
    {
        private ICollection<Node<T>> children;

        public Node(T value)
        {
            this.children = new List<Node<T>>();
            this.Value = value;
        }

        public Node(T value, Node<T> parent)
            : this(value)
        {
            this.Parent = parent;
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public ICollection<Node<T>> Children
        {
            get
            {
                return this.children;
            }

            set
            {
                this.children = value;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
