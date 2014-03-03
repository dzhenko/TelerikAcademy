//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). Example:
//{2, 2, 3, 3, 2, 3, 4, 3, 3}  3


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Majorant
{
    class Majorant
    {
        public static void Main()
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();

            int[] array = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            foreach (var num in array)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num]++;
                }
                else
                {
                    counter.Add(num, 1);
                }
            }

            foreach (var dictItem in counter)
            {
                if (dictItem.Value >= ((array.Length / 2) + 1))
                {
                    Console.WriteLine(dictItem.Key);
                    return;
                }
            }

            Console.WriteLine("No majorant found!");
        }
    }
}
