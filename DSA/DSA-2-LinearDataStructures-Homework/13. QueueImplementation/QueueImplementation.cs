//Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A new shiny queue implementation
    /// </summary>
    /// <typeparam name="T">The type of elements to store in the queue</typeparam>
    public class JQueue<T>
    {
        private readonly LinkedList<T> list;

        /// <summary>
        /// Default constructor
        /// </summary>
        public JQueue()
        {
            this.list = new LinkedList<T>();
        }

        /// <summary>
        /// Adds an element to the back of the queue
        /// </summary>
        /// <param name="item">The element to add</param>
        public void Enqueue(T item)
        {
            this.list.AddLast(item);
        }

        /// <summary>
        /// Gets the first element in the queue WITHOUT removing it
        /// </summary>
        /// <returns>The top first from the queue</returns>
        public T Peek()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }
            return this.list.First.Value;
        }

        /// <summary>
        /// Removes the first element from the queue
        /// </summary>
        /// <returns>The first element from the queue</returns>
        public T Dequeue()
        {
            T itemToGet = this.Peek();
            this.list.RemoveFirst();
            return itemToGet;
        }

        /// <summary>
        /// The number of elements in the queue
        /// </summary>
        public int Count { get { return this.list.Count; } }
    }
}
