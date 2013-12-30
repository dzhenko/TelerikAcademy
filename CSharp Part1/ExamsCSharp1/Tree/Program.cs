using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine(new string('.',n-2 - i) + new string('*',i*2 + 1) +new string('.',n-2 - i)) ;
            }
            Console.WriteLine(new string('.', n - 2) + "*" + new string('.', n - 2));
        }
    }
}
