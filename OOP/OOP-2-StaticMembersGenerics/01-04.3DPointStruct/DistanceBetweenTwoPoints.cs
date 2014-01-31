namespace Point3D
{
    using System;

    public static class Points3DOperations
    {
        public static double CalculateDistance(Point one,Point two)
        {
            return Math.Sqrt (
                (two.x - one.x) * (two.x - one.x) +
                (two.y - one.y) * (two.y - one.y) + 
                (two.z - one.z) * (two.z - one.z) ) ;
        }
    }
}
