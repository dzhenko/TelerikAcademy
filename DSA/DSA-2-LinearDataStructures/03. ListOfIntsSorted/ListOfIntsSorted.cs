//Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

using System.Text;

namespace _03.ListOfIntsSorted
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfIntsSorted
    {
        static void Main()
        {
            List<int> allElements = new List<int>();

            string line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                allElements.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            SortByAscendingOrder(allElements);

            for (int i = 0; i < allElements.Count; i++)
            {
                Console.WriteLine(allElements[i]);
            }
        }

        private static void SortByAscendingOrder(List<int> allElements)
        {
            for (int i = 0; i < allElements.Count; i++)
            {
                int currMin = i;
                for (int j = i + 1; j < allElements.Count; j++)
                {
                    if (allElements[j] < allElements[currMin])
                    {
                        currMin = j;
                    }
                }

                int helper = allElements[currMin];
                allElements[currMin] = allElements[i];
                allElements[i] = helper;
            }
        }
    }
}
