using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            int N3 = int.Parse(Console.ReadLine());
            int N4 = int.Parse(Console.ReadLine());
            int N5 = int.Parse(Console.ReadLine());
            decimal A = decimal.Parse(Console.ReadLine()); //given amount
            decimal P = decimal.Parse(Console.ReadLine()); //drink price
            
            

            if (A < P)
            {
                Console.WriteLine("More {0:F2}", P - A);
            }
            else
            {
                
                decimal Money = N1 * 0.05m + N2 * 0.10m + N3 * 0.20m + N4 * 0.50m + N5 * 1.00m;
                decimal left = Money - (A - P);
                if (Money < A - P)
                {
                    Console.WriteLine("No {0:F2}", (A - P) - Money);
                }
                else
                {
                    Console.WriteLine("Yes {0:F2}", left);
                }
            }
        }
    }
}
