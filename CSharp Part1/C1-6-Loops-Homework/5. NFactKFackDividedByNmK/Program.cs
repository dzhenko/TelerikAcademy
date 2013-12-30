//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).


using System;
using System.Numerics;

 class Program
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());
        BigInteger answer = ((Factoriel(n))*(Factoriel(k)))/(Factoriel(k-n));
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

