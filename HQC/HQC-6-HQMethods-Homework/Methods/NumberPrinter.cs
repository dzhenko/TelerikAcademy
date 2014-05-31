namespace Methods
{
    using System;

    public class NumberPrinter
    {
        public static void PrintAsDecimal(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintIdented(object number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
