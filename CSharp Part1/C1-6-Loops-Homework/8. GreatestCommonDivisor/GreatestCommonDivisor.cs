//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).


using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if (a == b)
        {
            Console.WriteLine("The numbers are the same");
            Environment.Exit(0);
        }
        if (a < b)
        {
            int c = a;
            a = b;
            b = c;
        }
        int reminder = 1;
        while (reminder != 0)
        {
            reminder = a % b;
            a = b;
            b = reminder;
        }
        Console.Write("The greatest common dividor of those two numbers is --> ");
        Console.WriteLine(a);
    }
}

