//Write a program that removes from given sequence all numbers that occur odd number of times. Example:
//{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}


namespace _06.RemoveOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddNumberOfTimes
    {
        static void Main()
        {
            List<int> listOfNumbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var dict = listOfNumbers.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());

            var numbersToKeep = listOfNumbers.Where(x => dict[x] % 2 == 0);

            listOfNumbers = numbersToKeep.ToList();

            Console.WriteLine(string.Join(", ",listOfNumbers));
        }
    }
}
