using System;

class InCircleOutOfRect
{
    static void Main()
    {
        Console.WriteLine("x -> ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("y -> ");
        double y = Convert.ToDouble(Console.ReadLine());
        bool outsideRect = (x > 5) || (x < -1) || (y < -1) || (y > 1);
        double distanceToCentre = (double)Math.Sqrt(Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2));
        bool insideCircle = distanceToCentre <= 3;
        if (outsideRect)
        {
            Console.WriteLine("The Point with those coords is OUTSIDE of the rectangle");
        }
        else
        {
            Console.WriteLine("The Point with those coords is INSIDE of the rectangle");
        }
        if (insideCircle)
        {
            Console.WriteLine("The Point with those coords is INSIDE of the circle");
        }
        else
        {
            Console.WriteLine("The Point with those coords is OUTSIDE of the circle");
        }
        if (outsideRect && insideCircle)
        {
            Console.WriteLine("So yes - the point is OUTSIDE of the rectangle and INSIDE the circle ... gratz");
        }
    }
}

