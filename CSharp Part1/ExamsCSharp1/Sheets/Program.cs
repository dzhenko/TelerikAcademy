using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheets
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string strinnumber = Convert.ToString(input, 2).PadLeft(11, '0');
            for (int i = 0; i < 11; i++)
            {
                if (strinnumber[i] == '0')
                {
                    Console.WriteLine("A"+i);
                }
            }
        }
    }
}
