namespace Methods
{
    using System;

    public class Distance
    {
        private const string PointCanNotBeNullException = "Point can not be null.";

        private double pointAX;
        private double pointAY;
        private double pointBX;
        private double pointBY;

        public Distance(double pointAX, double pointAY, double pointBX, double pointBY)
        {
            this.PointAX = pointAX;
            this.PointAY = pointAY;
            this.PointBX = pointBX;
            this.PointBY = pointBY;
        }

        public double PointAX
        {
            get
            {
                return this.pointAX;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException(PointCanNotBeNullException);
                }

                this.pointAX = value;
            }
        }

        public double PointAY
        {
            get
            {
                return this.pointAY;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException(PointCanNotBeNullException);
                }

                this.pointAY = value;
            }
        }

        public double PointBX
        {
            get
            {
                return this.pointBX;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException(PointCanNotBeNullException);
                }

                this.pointBX = value;
            }
        }

        public double PointBY
        {
            get
            {
                return this.pointBY;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException(PointCanNotBeNullException);
                }

                this.pointBY = value;
            }
        }

        public double Value
        {
            get
            {
                double distanceValue = Math.Sqrt(((this.PointBX - this.PointAX) * (this.PointBX - this.PointAX)) +
                                                    ((this.PointBY - this.PointAY) * (this.PointBY - this.PointAY)));
                return distanceValue;
            }
        }

        public bool IsHorizontal
        {
            get
            {
                bool horizontal = this.PointAY == this.PointBY;
                return horizontal;
            }
        }

        public bool IsVertical
        {
            get
            {
                bool vertical = this.PointAX == this.PointBX;
                return vertical;
            }
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
