using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekomap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("*" + new string ('.',n-1));
            for (int i = 1; i <= n - 2; i++)
            {
                Console.WriteLine(new string('.', i) + "*" + new string('.', n - 1 - i));
            }


            Console.WriteLine(new string('.', n - 1) + "*" );

            for (int i = 1; i <= n - 2; i++)
            {
                Console.WriteLine(new string('.', n - 1 - i) + "*" + new string('.',i ));
            }

            Console.WriteLine("*" + new string('.', n - 1));
        }
    }
}
