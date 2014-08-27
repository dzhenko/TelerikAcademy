//Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.QueueImplementation
{
    using System;
    using System.Linq;

    public class Testing
    {
        public static void Main()
        {
            var que = new JQueue<int>();

            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            Console.WriteLine(que.Peek());
            Console.WriteLine(que.Dequeue());
            Console.WriteLine(que.Peek());
            que.Enqueue(4);
            que.Enqueue(5);
            que.Enqueue(6);


            que.Enqueue(7);
            que.Enqueue(8);
        }
    }
}
