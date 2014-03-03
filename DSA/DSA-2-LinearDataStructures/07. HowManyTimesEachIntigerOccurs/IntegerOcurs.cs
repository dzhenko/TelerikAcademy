//Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2  2 times
//3  4 times
//4  3 times

namespace _07.HowManyTimesEachIntigerOccurs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerOcurs
    {
        public static void Main()
        {
            //using dictonary is too mainstream :D
            int[] ocurances = new int[1001];

            int[] integers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            foreach (var integer in integers)
            {
                ocurances[integer]++;
            }

            foreach (var ocurance in ocurances)
            {
                if (ocurance != 0)
                {
                    Console.WriteLine("{0} -> {1} times",ocurances[ocurance], ocurance);
                }
            }
        }
    }
}
