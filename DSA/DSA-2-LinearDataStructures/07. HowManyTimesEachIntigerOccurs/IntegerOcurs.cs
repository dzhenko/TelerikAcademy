//Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2  2 times
//3  4 times
//4  3 times

namespace _07.HowManyTimesEachIntigerOccurs
{
    using System;
    using System.Linq;

    public class IntegerOcurs
    {
        public static void Main()
        {
            int[] integers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var dict = integers.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());

            foreach (var pair in dict)
            {
                Console.WriteLine("{0} --> {1} times",pair.Key,pair.Value);
            }
        }
    }
}
