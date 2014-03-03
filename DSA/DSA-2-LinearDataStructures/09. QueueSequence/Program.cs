//We are given the following sequence:
//S1 = N;
//S2 = S1 + 1;
//S3 = 2*S1 + 1;
//S4 = S1 + 2;
//S5 = S2 + 1;
//S6 = 2*S2 + 1;
//S7 = S2 + 2;
//...
//Using the Queue<T> class write a program to print its first 50 members for given N.
//Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...


namespace _09.QueueSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class QueueSequence
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            int n = 2;

            queue.Enqueue(n);

            int stepCounter = 0;

            StringBuilder sb = new StringBuilder();

            while (stepCounter <= 50)
            {
                stepCounter++;
                int numToOperateOn = queue.Dequeue();
                sb.Append(numToOperateOn);
                sb.Append(", ");

                queue.Enqueue(numToOperateOn + 1);
                queue.Enqueue(2 * numToOperateOn + 1);
                queue.Enqueue(numToOperateOn + 2);
            }

            sb.Length--;
            sb.Length--;

            Console.WriteLine(sb);
        }
    }
}
