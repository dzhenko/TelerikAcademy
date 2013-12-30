//Write a program that calculates N!/K! for given N and K (1<K<N).


using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(Factoriel(n)/Factoriel(k));
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

