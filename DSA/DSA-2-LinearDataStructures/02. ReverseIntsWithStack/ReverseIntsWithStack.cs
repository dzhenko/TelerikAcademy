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

            Console.Write("How many numbers are you going to add: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter number {0}: ",i+1);
                nums.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Reversed order : ");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("number {0}: is {1}", i + 1,nums.Pop());
            }
        }
    }
}
