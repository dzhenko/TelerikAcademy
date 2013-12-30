using System;

public class Display
{
    //private constants
    private const int defaultHeight = 180;
    private const int defaultWidth = 120;
    private const long defaultNumberOfColors = 16000000;

    //fields
    private int height;
    private int width;
    private long numberOfColors;

    //property height
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
                throw new ArgumentException("Height must be > 0");
            }
            this.height = value;
        }
    }

    //property width
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
                throw new ArgumentException("Width must be > 0");
            }
            this.width = value;
        }
    }

    //property numberOfColors
    public long NumberOfColors
    {
        get 
        { 
            return numberOfColors; 
        }
        set 
        { 
            if (value <= 1)
            {
                throw new ArgumentException("Number of colors must be > 1");
            }
            numberOfColors = value; 
        }
    }

    //constructor with default properties
    public Display()
    {
        this.Height = defaultHeight;
        this.Width = defaultWidth;
        this.NumberOfColors = defaultNumberOfColors;
    }

    //constructor with input properties
    public Display(int height,int width, long numberOfColors)
    {
        this.Height = height;
        this.Width = width;
        this.NumberOfColors = numberOfColors;
    }

}

