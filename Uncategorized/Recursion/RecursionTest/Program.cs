using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] combo = new int[n];
            ComboGenerator(0, combo);
        }

        private static void ComboGenerator(int index, int[] array)
        {
            if (index == array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 1; i < array.Length; i++)
                {
                    array[index] = i;
                    ComboGenerator(index + 1, array);
                }
            }
        }
    }
}
