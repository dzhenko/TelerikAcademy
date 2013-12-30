//In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
//Write a program to calculate the Nth Catalan number by given N.


using System;
using System.Numerics;

class CatalansNumber
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger answer = Factoriel(2 * n) / (Factoriel(n + 1) * Factoriel(n));
        Console.WriteLine(answer);
    }

    private static BigInteger Factoriel(BigInteger n)
    {
        BigInteger factN = 1;
        while (n > 1)
        {
            factN = factN * (n);
            n = n - 1;
        }
        return factN;
    }
}

