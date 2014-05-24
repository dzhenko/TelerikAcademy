namespace FigureRotation
{
    using System;

    public class Rectangle
    {
        private const string WidthLessThanZeroExceptionMessage = "Width can not be less or equal to 0!";
        private const string HeightLessThanZeroExceptionMessage = "Height can not be less or equal to 0!";
        
        private double width;
        private double height;

        public Rectangle(double rectangleWidth, double rectangleHeight)
        {
            this.Width = rectangleWidth;
            this.Height = rectangleHeight;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(WidthLessThanZeroExceptionMessage);
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(HeightLessThanZeroExceptionMessage);
                }

                this.height = value;
            }
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
