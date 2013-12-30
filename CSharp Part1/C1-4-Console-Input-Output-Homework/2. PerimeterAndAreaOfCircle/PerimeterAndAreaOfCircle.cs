//Write a program that reads the radius r of a circle and prints its perimeter and area.


using System;

class PerimeterAndAreaOfCircle
{
    static void Main()
    {
        Console.WriteLine("Enter Radius :");
        double radius = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Perimeter is :  " + (2*Math.PI*radius));
        Console.WriteLine("Area is :  " + (Math.PI*Math.PI*radius));
    }
}

