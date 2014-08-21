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

            Console.Write("Enter a number: ");
            string line = Console.ReadLine();

            int n;
            int sum = 0;

            while (int.TryParse(line, out n))
            {
                if (n >= 0)
                {
                    allElements.Add(n);
                    sum += n;
                }

                Console.Write("Enter a number or something else to stop: ");
                line = Console.ReadLine();
            }

            Console.WriteLine("The sum of all elements is: {0}",sum);

            Console.WriteLine("The average of all elements is: {0}", sum / allElements.Count);
        }
    }
}
