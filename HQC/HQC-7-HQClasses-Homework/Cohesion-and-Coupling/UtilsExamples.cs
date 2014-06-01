namespace CohesionAndCoupling
{
    using System;

    using Utils;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped testParallelepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", testParallelepiped.Volume);
            Console.WriteLine("Diagonal XYZ = {0:f2}", testParallelepiped.DiagonalXYZ);
            Console.WriteLine("Diagonal XY = {0:f2}", testParallelepiped.DiagonalXY);
            Console.WriteLine("Diagonal XZ = {0:f2}", testParallelepiped.DiagonalXZ);
            Console.WriteLine("Diagonal YZ = {0:f2}", testParallelepiped.DiagonalYZ);
        }
    }
}

// ------ StyleCop completed ------
// 
// ========== Violation Count: 0 ==========
//
// :)
