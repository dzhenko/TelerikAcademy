namespace Methods
{
    using System;

    public class MethodsTesting
    {
        public static void Main()
        {
            Triangle testTriangle = new Triangle(3, 4, 5);
            Console.WriteLine(testTriangle.Area);

            Console.WriteLine(Translator.ConvertDigitToItsName(5));

            AdvancedArray testArray = new AdvancedArray(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine(testArray.MaxInteger);

            NumberPrinter.PrintAsDecimal(1.3);
            NumberPrinter.PrintAsPercent(0.75);
            NumberPrinter.PrintIdented(2.30);

            Distance testDistance = new Distance(3, -1, 3, 2.5);
            Console.WriteLine(testDistance.Value);
            Console.WriteLine("Horizontal? " + testDistance.IsHorizontal);
            Console.WriteLine("Vertical? " + testDistance.IsVertical);

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");
            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
