//Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).


using System;

class QuadraticЕquation
{
    static void Main()
    {
        Console.WriteLine("In the format   ax^2 + bx + c = 0 ");
        Console.WriteLine("Enter a coef. : ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter b coef. : ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter c coef. : ");
        double c = Convert.ToDouble(Console.ReadLine());
        double D = ((b * b) - (4 * a * c));
        double root1, root2;
        if (D < 0)
        {
            Console.WriteLine("No real roots");
            Environment.Exit(0);
        }
        if (D == 0)
        {
            root1 = ((-b+(Math.Sqrt(D)))/(2*a));
            Console.WriteLine("x1 = x2 = "+root1);
        }
        if (D>0)
        {
            root1 = ((-b+(Math.Sqrt(D)))/(2*a));
            root2 = ((-b - (Math.Sqrt(D))) / (2 * a));
            Console.WriteLine("x1 = "+root1);
            Console.WriteLine("x2 = " + root2);
        }
    }
}

