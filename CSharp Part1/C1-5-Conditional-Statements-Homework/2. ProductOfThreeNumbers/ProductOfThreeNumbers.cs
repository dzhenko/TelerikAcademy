//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.


using System;

class Program
{
    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        Console.Write("The sighn is : ");
        if (a < 0)
        {
            if (b < 0)
            {
                if (c<0)
                {
                    Console.WriteLine("-");
                }
                if (c>0)
                {
                    Console.WriteLine("+");
                }
            }
            if (b > 0)
            {
                if (c < 0)
                {
                    Console.WriteLine("+");
                }
                if (c > 0)
                {
                    Console.WriteLine("-");
                }
            }
        }
        if (a>0)
        {
            if (b < 0)
            {
                if (c < 0)
                {
                    Console.WriteLine("+");
                }
                if (c > 0)
                {
                    Console.WriteLine("-");
                }
            }
            if (b>0)
            {
                if (c < 0)
                {
                    Console.WriteLine("-");
                }
                if (c > 0)
                {
                    Console.WriteLine("+");
                }
            }
        }
        if (a == 0 || b == 0 || c ==0 )
        {
            Console.WriteLine("ZERO");
        }
    }
}

