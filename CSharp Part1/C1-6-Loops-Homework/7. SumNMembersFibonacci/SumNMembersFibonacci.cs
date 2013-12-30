//Write a program that reads a number N and calculates the sum of the first N members of the sequence 
//of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.


using System;

class SumNMembersFibonacci
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        ulong sum = 1;
        ulong a = 0;
        ulong b = 1;
        ulong next;
        for (ulong i = 0; i < n - 2; i++)
        {
            next = a + b;
            sum = sum + next;
            a = b;
            b = next;          
        }
        Console.WriteLine(sum);
    }
}

