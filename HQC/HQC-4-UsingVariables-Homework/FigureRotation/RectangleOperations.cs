namespace FigureRotation
{
    using System;

    public class RectangleOperations
    {
        public static Rectangle GetRotatedRectangle(
          Rectangle figureToRotate, double angleToRotateWith)
        {
            double newWidth = (Math.Abs(Math.Cos(angleToRotateWith)) * figureToRotate.Width) +
                (Math.Abs(Math.Sin(angleToRotateWith)) * figureToRotate.Height);
            double newHeight = (Math.Abs(Math.Sin(angleToRotateWith)) * figureToRotate.Width) +
                (Math.Abs(Math.Cos(angleToRotateWith)) * figureToRotate.Height);

            Rectangle newRectangle = new Rectangle(newWidth, newHeight);
            return newRectangle;
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
