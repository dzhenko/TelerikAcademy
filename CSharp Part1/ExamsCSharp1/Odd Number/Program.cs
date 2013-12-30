using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> numbers = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            string input;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                
                    if (numbers.ContainsKey(input))
                    {
                        numbers[input]++;
                    }
                    else
                    {
                        numbers.Add(input, 1);
                    }
            }
            foreach (var item in numbers)
            {
                if (item.Value % 2 != 0 )
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
