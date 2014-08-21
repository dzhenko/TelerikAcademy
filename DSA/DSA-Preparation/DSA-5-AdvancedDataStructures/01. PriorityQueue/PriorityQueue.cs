
namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Holds elements in a priority queue with a predefined rule of priority
    /// </summary>
    /// <typeparam name="T">The type of elements to keep</typeparam>
    public class PriorityQueue<T>
    {
        private BinaryHeap<T> queue;

        /// <summary>
        /// Default constructor using the default priority rules
        /// </summary>
        public PriorityQueue()
            : this(null) { }

        /// <summary>
        /// Constructor using predefined priority rules
        /// </summary>
        /// <param name="compararer">The compararer which will set the priority rules</param>
        public PriorityQueue(Comparer<T> compararer)
        {
            this.queue = new BinaryHeap<T>(compararer);
        }

        /// <summary>
        /// Adds an element in the queue
        /// </summary>
        /// <param name="element">The element to add in the queue</param>
        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }

        /// <summary>
        /// Returns the next element without removing it from the queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return this.queue.GetTopElement();
        }

        /// <summary>
        /// Returns the next element AND removing it from the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            T elementToReturn = this.queue.GetTopElement();

            this.queue.RemoveTop();

            return elementToReturn;
        }

        /// <summary>
        /// Deletes all the elements in the queue
        /// </summary>
        public void Clear()
        {
            this.queue.Clear();
        }
    }
}
