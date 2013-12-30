using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            char digit = char.Parse(Console.ReadLine());
            int numbers = int.Parse(Console.ReadLine());
            long[] inputInt = new long[numbers];
            for (int i = 0; i < numbers; i++)
            {
                inputInt[i] = long.Parse(Console.ReadLine());
            }
            string[] inputs = new string[numbers];
            for (int i = 0; i < numbers; i++)
            {
                inputs[i] = Convert.ToString(inputInt[i], 2);
            }
            int[] counters = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                foreach (char letter in inputs[i])
                {
                    if (letter == digit)
                    {
                        counters[i]++;
                    }
                }
            }
            foreach (int item in counters)
            {
                Console.WriteLine(item);
            }

        }
    }
}
