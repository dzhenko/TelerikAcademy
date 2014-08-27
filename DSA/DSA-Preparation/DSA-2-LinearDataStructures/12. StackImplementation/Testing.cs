namespace _12.StackImplementation
{
    using System;

    public class StackTesting
    {
        public static void Main()
        {
            var Testing = new JStack<int>();

            Testing.Push(1);
            Testing.Push(2);
            Console.WriteLine(Testing.Peek());
            Console.WriteLine(Testing.Pop());
            Console.WriteLine(Testing.Count);
            Console.WriteLine(Testing.Peek());
            Console.WriteLine(Testing.Count);
            Testing.Push(1);
            Testing.Push(2);
            Testing.Push(1);
            Testing.Push(2);
            Testing.Push(1);
            Testing.Push(2);
            Console.WriteLine(Testing.Count);


        }
    }
}