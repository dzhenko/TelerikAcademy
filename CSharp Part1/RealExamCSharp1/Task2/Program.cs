using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string numberInString = Console.ReadLine();
        numberInString= numberInString.TrimStart('-');
        int odd = 0;
        int even = 0;
        for (int i = 0; i < numberInString.Length; i++)
        {
            int digit = int.Parse(numberInString[i].ToString());
            if (digit % 2 == 0)
            {
                even += digit;
            }
            else
            {
                odd += digit;
            }
        }
        if (odd>even)
        {
            Console.WriteLine("left {0}",odd);
        }
        else if (odd<even)
        {
            Console.WriteLine("right {0}",even);
        }
        else
        {
            Console.WriteLine("straight {0}", even);
        }
    }
}

