namespace Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        List<Point> paths;

        public Path()
        {
            paths = new List<Point>();
        }

        public void AddPoint()
        {
            this.paths.Add(Point.Start);
        }

        public void AddPoint(Point point)
        {
            this.paths.Add(point);
        }

        public void AddPoint(int x, int y, int z)
        {
            this.paths.Add(new Point(x,y,z));
        }

        public override string ToString()
        {
            StringBuilder toStringer = new StringBuilder();
            int pathIndexer = 0;
            foreach (Point point in this.paths)
            {
                toStringer.AppendFormat("Point {0} --> ", pathIndexer);
                pathIndexer++;
                toStringer.AppendFormat("{0} , {1} , {2} \r\n", point.X,point.Y,point.Z);
            }
            return toStringer.ToString();
        }
    }
}
