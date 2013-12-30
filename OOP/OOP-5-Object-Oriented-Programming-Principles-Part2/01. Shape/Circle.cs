public class Circle : Shape
{
    public Circle(double diametur) : base(diametur, diametur) { }

    public override double CalculateSurface()
    {
        return (this.Height / 2) * (this.Width / 2) * System.Math.PI ;
    }
}