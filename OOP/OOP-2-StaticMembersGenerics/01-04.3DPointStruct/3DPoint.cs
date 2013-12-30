namespace Point3D
{
    using System;

    public struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        private static readonly Point start = new Point(0, 0, 0);
        public static Point Start 
        { 
            get
            {
                return start;
            }
        }

        public Point(int x, int y,int z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", this.x, this.y, this.z);
        }
    }
}
