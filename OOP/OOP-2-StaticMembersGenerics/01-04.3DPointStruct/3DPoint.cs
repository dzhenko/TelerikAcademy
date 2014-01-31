namespace Point3D
{
    using System;

    public struct Point
    {
        private static readonly Point start = new Point(0, 0, 0);
        
        public int x { get;private set; }
        public int y { get;private set; }
        public int z { get;private set; }

        public Point(int X, int Y, int Z)
            : this()
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
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
            return string.Format("({0},{1},{2})", this.x, this.y, this.z);
        }
    }
}
