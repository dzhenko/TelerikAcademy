//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
//sum, product, min, max, average.

namespace IEnumerableSumProductMinMaxAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> enumcollection)
        {
            bool flagEmptyCollection = true;
            dynamic sum = 0;
            foreach (var item in enumcollection)
            {
                flagEmptyCollection = false;
                sum += item;
            }
            if (flagEmptyCollection)
            {
                throw new ArgumentException("Empty Collection");
            }
            return (T)sum;
        }

        public static T Product<T>(this IEnumerable<T> enumcollection)
        {
            bool flagEmptyCollection = true;
            dynamic product = 1;
            foreach (var item in enumcollection)
            {
                flagEmptyCollection = false;
                product *= item;
            }
            if (flagEmptyCollection)
            {
                throw new ArgumentException("Empty Collection");
            }
            return (T)product;
        }

        public static T Average<T>(this IEnumerable<T> enumcollection)
        {
            dynamic sum = 0;
            dynamic count = 0;
            foreach (var item in enumcollection)
            {
                count++;
                sum += item;
            }
            if (count == 0)
            {
                throw new ArgumentException("Empty Collection");
            }
            return (T)(sum / count);
        }

        public static T GetMin<T>(this IEnumerable<T> enumcollection)
        {
            return enumcollection.Min();
        }

        public static T GetMax<T>(this IEnumerable<T> enumcollection)
        {
            return enumcollection.Max();
        }

    }
    public class IEnumerable
    {
        static void Main()
        {
            List<int> testInts = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            byte[] testByte = new byte[] { 1, 2, 3, 4, 5 };
            decimal[] testDecimal = new decimal[] { 1.0m, 2.5m, 4.5m, 7.5m, 11m };
            string[] testString = new string[] { "asd", "wtf", "Damn" };

            //testing Sum
            Console.WriteLine();
            Console.WriteLine("Testing Sum-----------------------------------------------");
            Console.WriteLine();

            int sumInts = testInts.Sum();
            Console.WriteLine(sumInts);

            byte sumBytes = testByte.Sum();
            Console.WriteLine(sumBytes);

            decimal sumDecimal = testDecimal.Sum();
            Console.WriteLine(sumDecimal);

            string sumStrings = testString.Sum();
            Console.WriteLine(sumStrings);

            //testing Product
            Console.WriteLine();
            Console.WriteLine("Testing Product-----------------------------------------------");
            Console.WriteLine();

            int prodInts = testInts.Product();
            Console.WriteLine(prodInts);

            byte prodBytes = testByte.Product();
            Console.WriteLine(prodBytes);

            decimal prodDecimal = testDecimal.Product();
            Console.WriteLine(prodDecimal);

            //string prodStrings = testString.Product();     //not any logical way to multiply strings
            //Console.WriteLine(prodStrings);                //not any logical way to multiply strings

            //testing Average
            Console.WriteLine();
            Console.WriteLine("Testing Average-----------------------------------------------");
            Console.WriteLine();

            int averageInts = testInts.Average();
            Console.WriteLine(averageInts);

            byte averageBytes = testByte.Average();
            Console.WriteLine(averageBytes);

            decimal averageDecimal = testDecimal.Average();
            Console.WriteLine(averageDecimal);

            //string averageStrings = testString.Average();     //not any logical way to average Strings
            //Console.WriteLine(arodStrings);                   //not any logical way to average Strings

            //testing Min
            Console.WriteLine();
            Console.WriteLine("Testing Min-----------------------------------------------");
            Console.WriteLine();

            int minInts = testInts.GetMin();
            Console.WriteLine(minInts);

            byte minBytes = testByte.GetMin();
            Console.WriteLine(minBytes);

            decimal minDecimal = testDecimal.GetMin();
            Console.WriteLine(minDecimal);

            string minStrings = testString.GetMin();
            Console.WriteLine(minStrings);

            //testing max
            Console.WriteLine();
            Console.WriteLine("Testing max-----------------------------------------------");
            Console.WriteLine();

            int maxInts = testInts.GetMax();
            Console.WriteLine(maxInts);

            byte maxBytes = testByte.GetMax();
            Console.WriteLine(maxBytes);

            decimal maxDecimal = testDecimal.GetMax();
            Console.WriteLine(maxDecimal);

            string maxStrings = testString.GetMax();
            Console.WriteLine(maxStrings);
        }
    }
}
