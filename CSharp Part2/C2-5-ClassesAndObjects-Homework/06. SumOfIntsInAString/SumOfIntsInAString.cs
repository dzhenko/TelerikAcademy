//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

namespace _06.SumOfIntsInAString
{
    using System;

    class SumOfIntsInAString
    {
        static void Main()
        {
            string[] rawData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int answer = 0;

            for (int i = 0; i < rawData.Length; i++)
            {
                answer+= int.Parse(rawData[i]);
            }

            Console.WriteLine(answer);
        }
    }
}
