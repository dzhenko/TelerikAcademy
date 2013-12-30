namespace Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        List<int[]> paths;

        public Path()
        {
            paths = new List<int[]>();
        }

        public void AddPoint()
        {
            this.paths.Add(new int[3]);
        }

        public void AddPoint(Point point)
        {
            this.paths.Add(new int[] { point.x, point.y, point.z });
        }

        public void AddPoint(int x, int y, int z)
        {
            this.paths.Add(new int[] { x, y, z });
        }

        public int this[int point,int coord] //just for practice
        {
            get
            {
                if (point <0 || point > this.paths.Count)
                {
                    throw new IndexOutOfRangeException("Path does not exist!");
                }
                if (coord < 0 || coord > 2)
                {
                    throw new IndexOutOfRangeException("Coord can be only 0 , 1 or 2 !");
                }
                return this.paths[point][coord];
            }

            set
            {
                if (coord < 0 || coord > 2)
                {
                    throw new IndexOutOfRangeException("Coord can be only 0 , 1 or 2 !");
                }
                this.paths[point][coord] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toStringer = new StringBuilder();
            int pathIndexer = 0;
            foreach (int[] point in this.paths)
            {
                toStringer.AppendFormat("Point {0} --> ", pathIndexer);
                pathIndexer++;
                toStringer.AppendFormat("{0} , {1} , {2} \r\n", point[0],point[1],point[2]);
            }
            return toStringer.ToString();
        }
    }
}
