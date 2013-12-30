using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong input = ulong.Parse(Console.ReadLine());
            List<string> allDigits = new List<string>(270);
            for (char i = 'A'; i <= 'Z'; i++)
            {
                allDigits.Add(i.ToString());
            }
            for (char i = 'a'; i <= 'i'; i++)
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                     allDigits.Add(i.ToString() + j);
                }
            }

            string answer = null;
            if (input == 0)
            {
                Console.WriteLine("A");
            }
            while (input!=0)
            {
                answer = allDigits[(int)(input%256)] + answer;
                input = input / 256;
            }
            Console.WriteLine(answer);
        }
    }
}
