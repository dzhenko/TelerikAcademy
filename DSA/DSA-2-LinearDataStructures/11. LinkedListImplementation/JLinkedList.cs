//Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and
//NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

namespace _11.LinkedListImplementation
{
    using System;
    using System.Linq;

    public class JLinkedList<T>
    {
        private ListItem firstElement;
        private int count;

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
        }

        public JLinkedList()
        {
            this.firstElement = null;
            this.count = 0;
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
            count++;
        }

        public int Count { get { return this.count; } }
    }
}
