using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    
    static void Main()
    {
        ulong a = ulong.Parse(Console.ReadLine());
        ulong b = ulong.Parse(Console.ReadLine());
        ulong c = ulong.Parse(Console.ReadLine());
        ulong d = ulong.Parse(Console.ReadLine());

        decimal first = (decimal)a / b;
        decimal second = (decimal)c / d;
        decimal fPS = first + second;

        if (fPS >= 1)
        {
            Console.WriteLine((ulong)fPS);
        }
        else
        {
            Console.WriteLine("{0:0.0000000000000000000000}", first + second);
        }
        
        ulong top = d*a + b*c;
        ulong bot = b*d;




        Console.WriteLine("{0}/{1}",top,bot);
    }
}

