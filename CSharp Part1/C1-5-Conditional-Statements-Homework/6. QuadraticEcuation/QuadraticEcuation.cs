//Write a program that enters the coefficients a, b and c of a quadratic equation
//a*x2 + b*x + c = 0
//and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.


using System;

class QuadraticEcuation
{
    static void Main()
    {
        Console.WriteLine("a = ? ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("b = ? ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("c = ? ");
        double c = Convert.ToDouble(Console.ReadLine());
        double d = (b * b) - (4 * a * c);
        if (d<0)
        {
            Console.WriteLine("There are NO real roots");
        }
        else if (d==0)
        {
            Console.Write("x1 = x2 =  ");
            Console.WriteLine((-b)/(4*a*c));
        }
        else
        {
            Console.Write("x1 =  ");
            Console.WriteLine(((-b)+Math.Sqrt(d) )/ (2 * a));
            Console.Write("x2 =  ");
            Console.WriteLine(((-b) - Math.Sqrt(d)) / (2 * a));
        }
    }
}

