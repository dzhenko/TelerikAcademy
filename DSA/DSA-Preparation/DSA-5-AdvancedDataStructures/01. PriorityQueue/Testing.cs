//Implement a class PriorityQueue<T> based on the data structure "binary heap".

using System.Text;

namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Comper : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class Testing
    {
        public static void Main()
        {
            //TestHeap1();

            //TestHeap2();

            var prirq = new PriorityQueue<string>();

            prirq.Enqueue("asd");
            prirq.Enqueue("zzz");
            prirq.Enqueue("aaaa");
            prirq.Enqueue("fffff");

            Console.WriteLine(prirq.Dequeue());
        }
  
        private static void TestHeap1()
        {
            var heap = new BinaryHeap<int>();

            heap.Add(4);
            heap.Add(7);
            heap.Add(1);
            heap.Add(777);
            heap.Add(12);
            heap.Add(3);

            heap.RemoveTop();

            heap.RemoveTop();

            Console.WriteLine(heap.GetTopElement());
        }

        private static void TestHeap2()
        {
            var comper = new Comper();

            var heap = new BinaryHeap<int>(comper);

            heap.Add(4);
            heap.Add(7);
            heap.Add(1);
            heap.Add(777);
            heap.Add(12);
            heap.Add(3);

            Console.WriteLine(heap.GetTopElement());
        }
    }
}
