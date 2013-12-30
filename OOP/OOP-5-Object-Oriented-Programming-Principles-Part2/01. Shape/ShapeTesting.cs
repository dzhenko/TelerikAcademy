using System;

class ShapeTesting
{
    static void Main()
    {
        Shape[] shapes = new Shape[] {
            new Circle(5),
            new Triangle(4,5),
            new Rectangle(5,3)
        };

        foreach (var item in shapes)
        {
            Console.WriteLine(item.CalculateSurface());
        }
    }
}

