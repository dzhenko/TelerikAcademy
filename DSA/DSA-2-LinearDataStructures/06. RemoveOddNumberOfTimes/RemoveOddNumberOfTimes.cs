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

            Dictionary<int, int> numberOfOcurencies = new Dictionary<int, int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (numberOfOcurencies.ContainsKey(listOfNumbers[i]))
                {
                    numberOfOcurencies[listOfNumbers[i]]++;
                }
                else
                {
                    numberOfOcurencies.Add(listOfNumbers[i], 1);
                }
            }

            var answer = listOfNumbers.FindAll(x => numberOfOcurencies[x] % 2 == 0).ToList();

            Console.WriteLine(string.Join(", ", answer));
        }
    }
}
