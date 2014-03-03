//Write a program that reads from the console a sequence of positive integer numbers.
//The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
//Keep the sequence in List<int>.


namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            List<int> allElements = new List<int>();

            string line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                allElements.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            Console.WriteLine(SumTheElements(allElements));

            Console.WriteLine(GetTheAverage(allElements));
        }

        private static double GetTheAverage(List<int> allElements)
        {
            return (double)SumTheElements(allElements) / allElements.Count;
        }

        private static int SumTheElements(List<int> allElements)
        {
            int sum = 0;
            for (int i = 0; i < allElements.Count; i++)
            {
                sum += allElements[i];
            }

            return sum;
        }
    }
}
