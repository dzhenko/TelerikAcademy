//Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.


using System;

class GreaterNumber
{
    static void Main()
    {
        Console.WriteLine("Enter First Number : ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Second Number : ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The greater number is "+Math.Max(a,b));
    }
}
