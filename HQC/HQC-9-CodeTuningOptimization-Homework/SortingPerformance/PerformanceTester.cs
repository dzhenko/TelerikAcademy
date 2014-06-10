namespace SortingPerformance
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class PerformanceTester
    {
        private static Stopwatch sw = new Stopwatch();

        public static void Main()
        {
            CheckInt();

            CheckDouble();

            CheckString();
        }

        private static void CheckInt()
        {
            IComparable[] randomArray1 = { 4, 2, 3, 7, 5, 9, 1, 8, 6 };
            IComparable[] randomArray2 = { 4, 2, 3, 7, 5, 9, 1, 8, 6 };
            IComparable[] randomArray3 = { 4, 2, 3, 7, 5, 9, 1, 8, 6 };

            IComparable[] sortedArray1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IComparable[] sortedArray2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IComparable[] sortedArray3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            IComparable[] reversedArray1 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            IComparable[] reversedArray2 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            IComparable[] reversedArray3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("-----------------------------INT-------------------------------");
            Console.WriteLine();

            Console.WriteLine("-------------Random Values-------------");
            CheckArrays(randomArray1, randomArray2, randomArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Sorted Values-------------");
            CheckArrays(sortedArray1, sortedArray2, sortedArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Reversed Values------------");
            CheckArrays(reversedArray1, reversedArray2, reversedArray3);
            Console.WriteLine();
        }

        private static void CheckDouble()
        {
            IComparable[] randomArray1 = { 4.1d, 2.1d, 3.1d, 7.1d, 5.1d, 9.1d, 1.1d, 8.1d, 6.1d };
            IComparable[] randomArray2 = { 4.1d, 2.1d, 3.1d, 7.1d, 5.1d, 9.1d, 1.1d, 8.1d, 6.1d };
            IComparable[] randomArray3 = { 4.1d, 2.1d, 3.1d, 7.1d, 5.1d, 9.1d, 1.1d, 8.1d, 6.1d };

            IComparable[] sortedArray1 = { 1.1d, 2.1d, 3.1d, 4.1d, 5.1d, 6.1d, 7.1d, 8.1d, 9.1d };
            IComparable[] sortedArray2 = { 1.1d, 2.1d, 3.1d, 4.1d, 5.1d, 6.1d, 7.1d, 8.1d, 9.1d };
            IComparable[] sortedArray3 = { 1.1d, 2.1d, 3.1d, 4.1d, 5.1d, 6.1d, 7.1d, 8.1d, 9.1d };

            IComparable[] reversedArray1 = { 9.1d, 8.1d, 7.1d, 6.1d, 5.1d, 4.1d, 3.1d, 2.1d, 1.1d };
            IComparable[] reversedArray2 = { 9.1d, 8.1d, 7.1d, 6.1d, 5.1d, 4.1d, 3.1d, 2.1d, 1.1d };
            IComparable[] reversedArray3 = { 9.1d, 8.1d, 7.1d, 6.1d, 5.1d, 4.1d, 3.1d, 2.1d, 1.1d };

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("----------------------------Double-----------------------------");
            Console.WriteLine();

            Console.WriteLine("-------------Random Values-------------");
            CheckArrays(randomArray1, randomArray2, randomArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Sorted Values-------------");
            CheckArrays(sortedArray1, sortedArray2, sortedArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Reversed Values------------");
            CheckArrays(reversedArray1, reversedArray2, reversedArray3);
            Console.WriteLine();
        }

        private static void CheckString()
        {
            IComparable[] randomArray1 = { "d", "b", "c", "g", "e", "i", "a", "h", "f" };
            IComparable[] randomArray2 = { "d", "b", "c", "g", "e", "i", "a", "h", "f" };
            IComparable[] randomArray3 = { "d", "b", "c", "g", "e", "i", "a", "h", "f" };

            IComparable[] sortedArray1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            IComparable[] sortedArray2 = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            IComparable[] sortedArray3 = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };

            IComparable[] reversedArray1 = { "i", "h", "g", "f", "e", "d", "c", "b", "a" };
            IComparable[] reversedArray2 = { "i", "h", "g", "f", "e", "d", "c", "b", "a" };
            IComparable[] reversedArray3 = { "i", "h", "g", "f", "e", "d", "c", "b", "a" };

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("----------------------------STRING-----------------------------");
            Console.WriteLine();

            Console.WriteLine("-------------Random Values-------------");
            CheckArrays(randomArray1, randomArray2, randomArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Sorted Values-------------");
            CheckArrays(sortedArray1, sortedArray2, sortedArray3);
            Console.WriteLine();

            Console.WriteLine("-------------Reversed Values------------");
            CheckArrays(reversedArray1, reversedArray2, reversedArray3);
            Console.WriteLine();
        }

        private static bool CheckIfSortedArray(IComparable[] arrayToCheck)
        {
            for (int i = 1; i < arrayToCheck.Length; i++)
            {
                if (arrayToCheck[i - 1].CompareTo(arrayToCheck[i]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void CheckArrays(IComparable[] arr1, IComparable[] arr2, IComparable[] arr3)
        {
            sw.Restart();
            Sorters.InsertionSort(arr1);
            sw.Stop();
            Console.WriteLine("Insertions sort sorted ({0}) -> " + sw.Elapsed, CheckIfSortedArray(arr1));

            sw.Restart();
            Sorters.Quicksort(arr2);
            sw.Stop();
            Console.WriteLine("Quicksort sort sorted ({0}) -> " + sw.Elapsed, CheckIfSortedArray(arr2));

            sw.Restart();
            Sorters.SelectionSort(arr3);
            sw.Stop();
            Console.WriteLine("SelectionSort sort sorted ({0}) -> " + sw.Elapsed, CheckIfSortedArray(arr3));
        }
    }
}
