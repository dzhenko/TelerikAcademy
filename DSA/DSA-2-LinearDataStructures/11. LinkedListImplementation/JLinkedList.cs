//Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and
//NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

namespace _11.LinkedListImplementation
{
    using System;
    using System.Linq;
    using System.Text;

    public class JLinkedList<T>
        where T : IComparable
    {
        private ListItem firstElement;

        private class ListItem
        {
            private T value;
            private ListItem nextItem;

            public ListItem(T value)
            {
                this.Value = value;
                this.Next = null;
            }

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public ListItem Next
            {
                get { return this.nextItem; }
                set { this.nextItem = value; }
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        public JLinkedList()
        {
            this.firstElement = null;
        }

        public T FirstElement
        {
            get
            {
                return this.firstElement.Value;
            }
        }

        public void AddItem(T element)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem(element);
            }

            else
            {
                var currentElement = this.firstElement;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }
                currentElement.Next = new ListItem(element);
            }
        }

        public void RemoveItem(T element)
        {
            if (this.firstElement == null)
            {
                //emptyList
                return;
            }

            var currentItem = this.firstElement;

            if (currentItem.Value.CompareTo(element) == 0)
            {
                //even if null it will work OK
                this.firstElement = currentItem.Next;
                return;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.CompareTo(element) == 0)
                {
                    currentItem.Next = currentItem.Next.Next;
                    return;
                }

                currentItem = currentItem.Next;
            }
        }

        public override string ToString()
        {
            if (this.firstElement == null)
            {
                return string.Format("[ ]");
            }

            StringBuilder sb = new StringBuilder("[ ");
            
            var currItem = this.firstElement;
            sb.Append(currItem.Value);

            while (currItem.Next != null)
            {
                sb.Append(", ");
                sb.Append(currItem.Next);
                currItem = currItem.Next;
            }

            sb.Append(" ]");

            return sb.ToString();
        }

        public void AddFirst(T element)
        {
            var newNode = new ListItem(element);
            newNode.Next = this.firstElement;
            this.firstElement = newNode;
        }

        public void RemoveFirst()
        {
            this.firstElement = this.firstElement.Next;
        }
    }
}
