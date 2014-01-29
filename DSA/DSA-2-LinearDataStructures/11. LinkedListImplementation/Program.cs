//Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and
//NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JLinkedList<T>
    {
        private ListItem<T> head;
        private ListItem<T> tail;
        private int count;

        private class ListItem<T>
        {
            private T value;
            private ListItem<T> nextItem;

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public ListItem<T> Next
            {
                get { return this.nextItem; }
                set { this.nextItem = value; }
            }

            public ListItem(T value, ListItem<T> previousItem)
            {
                this.value = value;
                previousItem.Next = this;
            }

            public ListItem(T value)
            {
                this.value = value;
                this.Next = null;
            }
        }

        public JLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void AddItem(T element)
        {
            if (this.head == null)
            {
                this.head = new ListItem<T>(element);
                this.tail = this.head;
            }

            else
            {
                this.tail = new ListItem<T>(element, this.tail);
            }
            count++;
        }

        public int Count { get { return this.count; } }
    }
}
