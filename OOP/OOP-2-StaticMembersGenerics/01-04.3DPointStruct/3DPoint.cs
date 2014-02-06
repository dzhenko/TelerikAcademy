namespace Point3D
{
    using System;

    public struct Point
    {
        private static readonly Point start = new Point(0, 0, 0);
        
        public int X { get;private set; }
        public int Y { get;private set; }
        public int Z { get;private set; }

        public Point(int coordX, int coordY, int coordZ)
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
