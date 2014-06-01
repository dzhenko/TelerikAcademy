namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private const string RadiusCanNotBeNegativeException = "Radius can not be <= 0";

        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(RadiusCanNotBeNegativeException);
                }

                this.radius = value;
            }
        }

        public override double Perimeter
        {
            get
            {
                double perimeter = 2 * Math.PI * this.Radius;
                return perimeter;
            }
        }

        public override double Area
        {
            get
            {
                double surface = Math.PI * this.Radius * this.Radius;
                return surface;
            }
        }

        public override string ToString()
        {
            return "I am a circle. " + base.ToString();
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)