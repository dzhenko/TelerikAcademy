namespace Point3D
{
    using System;

    public class Test3DPoint
    {
        public static void Main()
        {
            Test1and2and3();

            Test4();
        }

        public static void Test4()
        {
            Path test1 = new Path();
            test1.AddPoint();
            test1.AddPoint(new Point(1, 2, 3));
            test1.AddPoint(4, 5, 6);


            Console.WriteLine(test1); // testing toString for a path

            PathStorage.WritePathToFile("testing.txt", test1);

            Path readFromFile = PathStorage.ReadPathFromFile("readMe.txt");

            Console.WriteLine(readFromFile);
        }

        public static void Test1and2and3()
        {
            Point test1 = new Point(1, 2, 3);
            Point test2 = new Point(2, 3, 4);

            Console.WriteLine(test1);
            Console.WriteLine(test2);

            Console.WriteLine(Point.Start);

            Console.WriteLine(Points3DOperations.CalculateDistance(test1, test2));
        }
    }
}
