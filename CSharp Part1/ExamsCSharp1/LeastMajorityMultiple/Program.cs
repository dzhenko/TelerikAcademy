using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastMajorityMultiple
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[5];
            numbers[0] = int.Parse(Console.ReadLine());
            numbers[1] = int.Parse(Console.ReadLine());
            numbers[2] = int.Parse(Console.ReadLine());
            numbers[3] = int.Parse(Console.ReadLine());
            numbers[4] = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1; i < 400000000; i++)
            {
                counter = 0;
                if (i % numbers[0] == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
                if (i % numbers[1] == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
                if (i % numbers[2] == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
                if (i % numbers[3] == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
                if (i % numbers[4] == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }
    }
}
