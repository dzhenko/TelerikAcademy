//Implement an extension method Substring(int index, int length) for the class StringBuilder 
//that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace _01.SubstringStringBuilder
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        //both start and lenghth
        public static StringBuilder Substring(this StringBuilder input,int startIndex,int length)
        {
            return new StringBuilder(input.ToString().Substring(startIndex, length));
        }

        //only startIndex
        public static StringBuilder Substring(this StringBuilder input, int startIndex)
        {
            return new StringBuilder(input.ToString().Substring(startIndex));
        }
    }

    public class StringBuilderExtensionsTester
    {
        static void Main()
        {
            StringBuilder test1 = new StringBuilder();
            test1.Append("hello I will try to remove the hello part");

            StringBuilder result1 = test1.Substring(6);
            StringBuilder result2 = test1.Substring(13, 14);

            Console.WriteLine(test1);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine();
        }
    }
}
