using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger count = 2;
            while (true)
            {
                
                Console.WriteLine(count);
                count = count * count;
            }
        }
    }
}
