//Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.


using System;

class NotDivisibleToSevenAndThree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i % 35 ==0)
            {
                continue;
            }
            Console.Write(i);
            Console.Write(", ");
        }
    }
}

