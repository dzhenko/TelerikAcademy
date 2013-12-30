using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string allthebits = null;

            for (int i = 0; i < n; i++)
            {
                allthebits = allthebits + Convert.ToString((int.Parse(Console.ReadLine())),2);
            }

            long answer = 0;
            long count0 = 0;
            long count1 = 0;

            foreach (char digit in allthebits)
            {
                if (digit == '0')
                {
                    if (count1 == k)
                    {
                        answer++;
                        count1 = 0;
                    }
                    else
                    {
                        count1 = 0;
                    }
                    count0++;
                }
                else
                {
                    if (count0 == k)
                    {
                        answer++;
                        count0 = 0;
                    }
                    else
                    {
                        count0 = 0;
                    }
                    count1++;
                }
            }
            if (count1==k)
            {
                answer++;
            }
            if (count0 ==k)
            {
                answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
