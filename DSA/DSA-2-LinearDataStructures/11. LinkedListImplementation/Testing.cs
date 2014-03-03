using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.LinkedListImplementation
{
    public class Testing
    {
        public static void Main()
        {
            var test = new JLinkedList<int>();

            Console.WriteLine(test.Count);

            test.AddItem(7);

            test.AddItem(18);

            Console.WriteLine(test.Count);

            test.AddItem(22);

            Console.WriteLine(test.Count);
        }
    }
}
