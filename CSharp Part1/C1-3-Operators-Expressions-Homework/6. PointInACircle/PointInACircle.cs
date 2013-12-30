using System;

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("x is? ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("y is? ");
        double y = Convert.ToDouble(Console.ReadLine());
        double distanceFromCentre = Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
        if (distanceFromCentre <= 5)
        {
            Console.WriteLine("The point with those coordinats is INSIDE the circle");
        }
        else
        {
            Console.WriteLine("The point with those coordinats is OUTSIDE the circle");
        }
    }
}

