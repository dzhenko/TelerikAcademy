namespace GsmClass
{
    using System;

    public class Display
    {
        private const int defaultHeight = 180;
        private const int defaultWidth = 120;
        private const long defaultNumberOfColors = 16000000;

        private int height;
        private int width;
        private long numberOfColors;

        public Display()
            : this(defaultHeight, defaultWidth, defaultNumberOfColors) { }

        public Display(int height, int width, long numberOfColors)
        {
            this.Height = height;
            this.Width = width;
            this.NumberOfColors = numberOfColors;
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Height must be > 0");
                }
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Width must be > 0");
                }
                this.width = value;
            }
        }

        public long NumberOfColors
        {
            get
            {
                return numberOfColors;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Number of colors must be > 0");
                }
                numberOfColors = value;
            }
        }
    }
}