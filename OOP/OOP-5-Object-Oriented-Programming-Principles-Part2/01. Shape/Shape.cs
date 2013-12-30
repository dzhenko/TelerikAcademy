public abstract class Shape
{
    private double width;
    private double height;

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
                throw new System.ArgumentException("Width can not be less than or equal to 0!");
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
                throw new System.ArgumentException("Height can not be less than or equal to 0!");
            }
            this.height = value;
        }
    }

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public abstract double CalculateSurface();
}