using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] input = new int[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }
            int answer = 0;
            string currentNum = null;
            for (int i = 0; i < n; i++)
            {
                answer = 0;
                currentNum = Convert.ToString(input[i], 2);

                for (int bit = 0; bit < currentNum.Length; bit++)
                {
                    if (currentNum[bit] == '1')
                    {
                        answer = answer + (int)Math.Pow(2, bit);
                    }
                }
                Console.WriteLine(answer);
            }
        }
    }
}
