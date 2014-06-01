namespace CohesionAndCoupling
{
    using System;

    using Utils;

    public class Parallelepiped
    {
        private const string WidthInvalidValueException = "Width can not be <= 0.";
        private const string HeightInvalidValueException = "Height can not be <= 0.";
        private const string DepthInvalidValueException = "Depth can not be <= 0.";

        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(WidthInvalidValueException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(HeightInvalidValueException);
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(DepthInvalidValueException);
                }

                this.depth = value;
            }
        }

        public double Volume
        {
            get
            {
                double volume = this.Width * this.Height * this.Depth;
                return volume;
            }
        }

        public double DiagonalXYZ
        {
            get
            {
                double distance = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
                return distance;
            }
        }

        public double DiagonalXY
        {
            get
            {
                double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
                return distance;
            }
        }

        public double DiagonalXZ
        {
            get
            {
                double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
                return distance;
            }
        }

        public double DiagonalYZ
        {
            get
            {
                double distance = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
                return distance;
            }
        }
    }
}

// ------ StyleCop completed ------
// 
// ========== Violation Count: 0 ==========
//
// :)
