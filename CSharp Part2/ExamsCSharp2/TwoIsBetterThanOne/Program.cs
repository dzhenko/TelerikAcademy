using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIsBetterThanOne
{
    class Program
    {
        static long start;
        static long end;
        static int task1Counter = 0;

        static List<int> numbers = new List<int>();

        static void Main()
        {
            Task1();

            Console.WriteLine(task1Counter);

            Task2();


        }

        private static void Task2()
        {
            foreach (var item in Console.ReadLine().Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
            {
                numbers.Add(int.Parse(item));
            }

            int p = int.Parse(Console.ReadLine());

            numbers.Sort();

            //smallest element E that at least P percent of the number are less than or equel to E
            Console.WriteLine(numbers[(int)(numbers.Count * (p / 100.01))]);
        }

        private static void Task1()
        {
            string[] RawInput = Console.ReadLine().Split();
            start = long.Parse(RawInput[0]);
            end = long.Parse(RawInput[1]);

            GenerateNumbers(0, 0);
        }

        private static void GenerateNumbers(int position, long number)
        {
            if (number >= start && number<=end && IsPolindom(number))
            {
                task1Counter++;
            }
            if (position > end.ToString().Length)
            {
                return;
            }
            GenerateNumbers(position + 1, number * 10 + 3);
            GenerateNumbers(position + 1, number * 10 + 5);
        }

        private static bool IsPolindom(long number)
        {
            string currNum = number.ToString();
            for (int i = 0; i < currNum.Length / 2 ; i++)
            {
                if (currNum[i] != currNum[currNum.Length-1-i])
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
