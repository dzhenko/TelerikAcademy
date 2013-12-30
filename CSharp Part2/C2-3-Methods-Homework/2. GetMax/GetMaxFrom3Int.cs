//Write a method GetMax() with two parameters that returns the bigger of two integers. 
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().


using System;

class GetMaxFrom3Int
{
    static int GetMax(int one, int two, int three)
    {
        return Math.Max(Math.Max(one, two), three);
    }

    static void Main()
    {
        Console.Write("Enter first integer : ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter second integer : ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("Enter third integer : ");
        int third = int.Parse(Console.ReadLine());
        int maximum = GetMax(first, second, third);

        Console.WriteLine("The maximum number is " +maximum);
        
    }
}

