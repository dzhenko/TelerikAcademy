using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly Heap<T> heap;

        public PriorityQueue(bool minPriority)
        {
            this.heap = new Heap<T>(minPriority);
        }

        public T Peek()
        {
            return this.heap.First();
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            var element = this.heap.First();
            this.heap.DeleteFirst();
            return element;
        }
    }
}
