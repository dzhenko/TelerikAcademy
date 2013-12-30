//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

namespace _04.TriangleSurface
{
    using System;

    class TriangleSurface
    {
        public static double SideAltitudeTriangleArea(double side, double altitude)
        {
            return side * altitude / 2;
        }

        public static double TreeSidesTriangleArea(double side1, double side2, double side3)
        {
            double perimeter = side1+side2+side3;
            return Math.Sqrt(perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3));
        }

        public static double AngleSidesTriangleArea(double side1, double side2, double angle)
        {
            return side1 * side2 * Math.Sin((angle * Math.PI) / 180);
        }

        static void Main()
        {
            Console.WriteLine(SideAltitudeTriangleArea(13,2));

            Console.WriteLine(TreeSidesTriangleArea(2,3,4));

            Console.WriteLine(AngleSidesTriangleArea(10,20,30));
            
        }
    }
}
