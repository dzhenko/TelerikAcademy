//Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace _17.MaxLengthString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MaxLStr
    {
        public static int longestElement = 0;

        public static void Main()
        {
            string[] stringArray = GenerateRandomStrings();

            string answerWithExtension = stringArray.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);

            Console.WriteLine(answerWithExtension);

            var answerWithQuery = from st in stringArray
                                     where GetLongerStr(st)
                                     select st;

            Console.WriteLine(answerWithQuery.Last());
        }

        private static bool GetLongerStr(string st)
        {
            if (st.Length > longestElement)
            {
                longestElement = st.Length;
                return true;
            }
            return false;
        }

        private static string[] GenerateRandomStrings()
        {
            Random rnd = new Random();

            string[] array = new string[rnd.Next(20, 31)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string((char)rnd.Next(65, 94), rnd.Next(1, 50));
            }

            return array;
        }
    }
}
