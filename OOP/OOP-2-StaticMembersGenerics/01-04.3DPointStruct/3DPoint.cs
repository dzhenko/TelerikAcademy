namespace Point3D
{
    using System;

    public struct Point
    {
        private static readonly Point start = new Point(0, 0, 0);
        
        public double X { get;private set; }
        public double Y { get;private set; }
        public double Z { get;private set; }

        public Point(double coordX, double coordY, double coordZ)
            : this()
        {
            this.X = coordX;
            this.Y = coordY;
            this.Z = coordZ;
        }

        public static Point Start 
        { 
            get
            {
                return start;
            }
        }
        
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", this.X, this.Y, this.Z);
        }
    }
}
