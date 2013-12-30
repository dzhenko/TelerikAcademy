using System;

class Program
{
    static void Main(string[] args)
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());
        decimal top, bottom, added;
        top = (N * N) + ((1) / (M * P)) + 1337;
        bottom = N - (128.523123123M * P);
        added = (decimal)Math.Sin((double)(((int)M) % 180));
        Console.WriteLine("{0:F6}", (top / bottom) + added);
    }
}

