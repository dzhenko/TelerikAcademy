using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class PriorityQueueTests
    {
        static void Main(string[] args)
        {
            HeapTest();

            var queue = new PriorityQueue<int>(true);

            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(1);

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }

        private static void HeapTest()
        {
            var heap = new Heap<int>(false);

            heap.Add(3);

            heap.Add(4);

            heap.Add(8);

            heap.Add(2);

            heap.Add(1);

            heap.DeleteFirst();

            heap.DeleteFirst();
        }
    }
}
