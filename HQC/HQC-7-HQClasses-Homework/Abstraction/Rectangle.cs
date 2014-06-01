namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private const string WidthCanNotBeNegativeException = "Width can not be <= 0";
        private const string HeightCanNotBeNegativeException = "Height can not be <= 0";

        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
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
                    throw new ArgumentException(WidthCanNotBeNegativeException);
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
                    throw new ArgumentException(HeightCanNotBeNegativeException);
                }

                this.height = value;
            }
        }

        public override double Perimeter
        {
            get
            {
                double perimeter = 2 * (this.Width + this.Height);
                return perimeter;
            }
        }

        public override double Area
        {
            get
            {
                double surface = this.Width * this.Height;
                return surface;
            }
        }

        public override string ToString()
        {
            return "I am a rectangle. " + base.ToString();
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
