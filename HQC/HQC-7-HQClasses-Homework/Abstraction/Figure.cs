namespace Abstraction
{
    public abstract class Figure
    {
        public abstract double Perimeter
        {
            get;
        }

        public abstract double Area
        {
            get;
        }

        public override string ToString()
        {
            return string.Format("My perimeter is {0:f2}. My surface is {1:f2}.", this.Perimeter, this.Area);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
