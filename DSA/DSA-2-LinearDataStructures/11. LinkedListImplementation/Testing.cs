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
            var org = new LinkedList<int>();

            var test = new JLinkedList<int>();

            test.AddItem(7);

            test.AddItem(18);

            test.AddItem(22);

            Console.WriteLine(test);

            test.RemoveItem(181);

            Console.WriteLine(test);
        }
    }
}
