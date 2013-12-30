//* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//	N = 20  N! = 2432902008176640000  4
//	Does your program work for N = 50 000?
//	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
//http://www.stat.ualberta.ca/people/schmu/preprints/factorial.pdf


using System;
using System.Numerics;

class Loops
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger limiter = 1;
        BigInteger zeroCounter = 0;
        BigInteger countNow;
        while (limiter < n)
        {
            limiter *= 5;
            countNow = 0;
            countNow = n / limiter;
            zeroCounter += countNow;         
        }
        Console.Write(n);
        Console.Write("!");
        Console.Write("   has exactly trailing zeros  ");
        Console.WriteLine(zeroCounter);
        Console.WriteLine("if you're curious just read the last two pages of the link :)");
    }
}

