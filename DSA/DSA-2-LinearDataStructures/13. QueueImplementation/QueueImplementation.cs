//Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class JQueue<T>
    {
        private LinkedList<T> list;

        public JQueue()
        {
            this.list = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.list.AddLast(item);
        }

        public T Peek()
        {
            return this.list.First.Value;
        }

        public T Dequeue()
        {
            T itemToGet = this.Peek();
            this.list.RemoveFirst();
            return itemToGet;
        }
    }
}
