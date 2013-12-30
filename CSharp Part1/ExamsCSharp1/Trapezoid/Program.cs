using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('.',n) + new string('*',n));
            for (int i = 1; i <= n-1; i++)
            {
                Console.WriteLine(new string('.', n-i) +"*"+ new string('.', n - 2  + i)+"*");
            }
            Console.WriteLine(new string('*',2*n));
        }
    }
}
