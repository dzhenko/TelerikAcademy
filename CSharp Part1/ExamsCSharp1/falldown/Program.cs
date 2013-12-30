using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falldown
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[8];
            for (int i = 0; i < 8; i++)
            {
                input[i] = (Convert.ToString(int.Parse(Console.ReadLine()), 2)).PadLeft(8,'0');
            }
            int[] ones = new int[8];
            int counter;
            for (int i = 0; i < 8; i++)
            {
                counter = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (input[j][i] == '1')
                    {
                        counter++;
                    }
                }
                ones[i] = counter;
            }
            int[] answer = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if (ones[0] > 7 - i)
                {
                    answer[i] = answer[i] + 128;
                }
                if (ones[1] > 7 - i)
                {
                    answer[i] = answer[i] + 64;
                }
                if (ones[2] > 7 - i)
                {
                    answer[i] = answer[i] + 32;
                }
                if (ones[3] > 7 - i)
                {
                    answer[i] = answer[i] + 16;
                }
                if (ones[4] > 7 - i)
                {
                    answer[i] = answer[i] + 8;
                }
                if (ones[5] > 7 - i)
                {
                    answer[i] = answer[i] + 4;
                }
                if (ones[6] > 7 - i)
                {
                    answer[i] = answer[i] + 2;
                }
                if (ones[7] > 7 - i)
                {
                    answer[i] = answer[i] + 1;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(answer[i]);
            }
        }
    }
}
