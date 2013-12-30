//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

namespace _24.ListOfWordsByAlphaOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfWordsByAlphaOrder
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] rawWords = input.Split();
            var ordered = rawWords.OrderBy(x => x);
            foreach (var item in ordered)
            {
                Console.WriteLine(item);
            }
        }
    }
}
