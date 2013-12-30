//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN


using System;
using System.Numerics;

class SumOfNX
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double sum = 1;
        double answer;
        double top;
        double bottom;
        for (double i = 1; i <= n; i++)
			{
                top = Factoriel(i);
                bottom = Math.Pow(x,i);
                answer = top / bottom;
                sum = sum + answer;
			}
        Console.WriteLine(sum);
    }

    private static double Factoriel(double n)
    {
        double factN = 1;
        while (n > 1)
        {
            factN = factN * (n);
            n = n - 1;
        }
        return factN;
    }
}

