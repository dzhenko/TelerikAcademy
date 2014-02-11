namespace Point3D
{
    using System;

    public static class Points3DOperations
    {
        public static double CalculateDistance(Point one,Point two)
        {
            return Math.Sqrt (
                (two.X - one.X) * (two.X - one.X) +
                (two.Y - one.Y) * (two.Y - one.Y) + 
                (two.Z - one.Z) * (two.Z - one.Z) ) ;
        }
    }
}
