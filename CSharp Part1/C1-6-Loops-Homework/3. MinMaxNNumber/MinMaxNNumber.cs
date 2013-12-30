//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.


using System;

class MinMaxNNumber
{
    static void Main()
    {
        Console.WriteLine("How many numbers will there be?");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("number "+(i+1)+" ?  ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int max = numbers[0];
        int min = max;
        for (int i = 0; i < n; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        Console.WriteLine("Minimal number is "+min+"   whereas the maximum is "+max);
    }
}

