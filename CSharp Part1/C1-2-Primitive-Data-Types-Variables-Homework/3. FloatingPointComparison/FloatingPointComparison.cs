using System;

    class FloatingPointComparison
    {
        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            float first = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            float second = float.Parse(Console.ReadLine());
            Console.Write("Are they equal -> ");
            Console.WriteLine(first == second);
        }
    }

