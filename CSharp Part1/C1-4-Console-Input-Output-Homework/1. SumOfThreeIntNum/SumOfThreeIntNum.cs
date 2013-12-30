//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class SumOfThreeIntNum
{
    static void Main()
    {
        Console.WriteLine("Enter First Number :");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Second Number :");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Third Number :");
        string numC = Console.ReadLine();
        int c;
        Int32.TryParse(numC, out c);
        Console.WriteLine(a+b+c);
    }
}

