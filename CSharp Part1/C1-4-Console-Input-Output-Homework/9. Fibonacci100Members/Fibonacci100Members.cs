//Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …


using System;
using System.Numerics; 

    class Fibonacci100Members
    {
        static void Main()
        {
            Console.Write("0,  1,  1,  ");
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger next;
            for (int i = 1; i <= 97; i++)
            {
                next = a + b;
                Console.Write(next);
                Console.Write(",  ");
                a = b;
                b = next;
            }
        }
    }

