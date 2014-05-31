namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Those are not sides of a triangle.");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));

            return area;
        }

        public static string ConvertDigitToItsName(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            return "Invalid digit!";
        }

        public static int FindMaxInteger(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There are no elements to look in.");
            }

            var maxElementIndex = 0;

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[maxElementIndex])
                {
                    maxElementIndex = i;
                }
            }

            return elements[maxElementIndex];
        }


        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertDigitToItsName(5));
            
            Console.WriteLine(FindMaxInteger(5, -1, 3, 2, 14, 2, 3));

            NumberPrinter.PrintAsDecimal(1.3);
            NumberPrinter.PrintAsPercent(0.75);
            NumberPrinter.PrintIdented(2.30);

            Distance distance = new Distance(3, -1, 3, 2.5);
            Console.WriteLine(distance.Value);
            Console.WriteLine("Horizontal? " + distance.IsHorizontal);
            Console.WriteLine("Vertical? " + distance.IsVertical);

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");
            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
