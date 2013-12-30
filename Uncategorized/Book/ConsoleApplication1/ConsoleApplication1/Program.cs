using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n > 5)
	        {
                Console.WriteLine((n/2) + 2);
	        }
            else
            {
                Console.WriteLine(n/2);
            }
        }
    }
}
