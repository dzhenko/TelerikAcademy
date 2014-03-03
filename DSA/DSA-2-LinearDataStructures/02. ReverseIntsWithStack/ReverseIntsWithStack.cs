//Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.

namespace _02.ReverseIntsWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseIntsWithStack
    {
        public static void Main()
        {
            Stack<int> nums = new Stack<int>();

            Console.Write("Enter number or something else to stop: ");

            string line = Console.ReadLine();

            int n;

            while (int.TryParse(line,out n))
            {
                nums.Push(n);
                Console.Write("Enter number or something else to stop: ");
                line = Console.ReadLine();
            }

            Console.WriteLine("Reversed order : ");

            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
