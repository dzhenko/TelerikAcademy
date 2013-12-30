using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n/2; i++)
            {
                Console.WriteLine(new string('.', i) + new string('*',n - 2*i) + new string('.',i));
            }
            Console.WriteLine(new string ('.',n/2) + "*" +new string ('.',n/2)) ;
            for (int i = n/2 - 1; i >= 0; i--)
            {
                Console.WriteLine(new string('.', i) + new string('*', n - 2 * i) + new string('.', i));
            }
        }
    }
}
