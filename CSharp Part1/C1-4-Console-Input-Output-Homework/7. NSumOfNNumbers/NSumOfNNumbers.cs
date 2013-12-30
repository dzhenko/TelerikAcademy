//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 


using System;

class NSumOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter Amount of numbers :");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Enter the "+i+"th number : ");
            sum = Convert.ToInt32(Console.ReadLine()) + sum;
        }
        Console.WriteLine("The sum is "+sum);
    }
}

