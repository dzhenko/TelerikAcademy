using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikLogo
{
    class Program
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int totalwidth = 3*x - 2;
            int redoveSRoga = x / 2 + 1;
            Console.WriteLine(new string('.', redoveSRoga - 1) + "*" + new string('.', x * 3 - 2 - 2 * redoveSRoga) + "*"
                    + new string('.', redoveSRoga - 1));
            for (int i = 1; i < redoveSRoga; i++)
            {
                Console.WriteLine(new string('.', redoveSRoga - i - 1) + "*"
                    + new string('.',i*2 - 1) + "*"
                    + new string('.', x * 3 - 2 - 2 * redoveSRoga - 2 * i) + "*"
                    + new string('.',i*2 - 1)  + "*" 
                    + new string('.', redoveSRoga - i - 1));
            }

            int dotsuntillmiddle = x * 3 - 2 - 2 * redoveSRoga - 2 * (redoveSRoga - 1);

            for (int i = 1; i <= dotsuntillmiddle/2; i++)
            {
                Console.WriteLine(new string('.',(totalwidth - dotsuntillmiddle - i*2)/2 + i*2 - 1)+
                    "*" + new string('.', dotsuntillmiddle - 2 * i) +
                    "*" + new string('.', (totalwidth - dotsuntillmiddle - i * 2) / 2 + i*2 - 1));
            }

            Console.WriteLine(new string('.', totalwidth / 2) + "*" + new string('.', totalwidth / 2));
            int helper = 0;
            for (int i = 1; i <= x - 2; i++)
            {
                helper = (totalwidth - i*2 - 1) / 2;
                Console.WriteLine(new string('.', helper) + "*" +new string('.', i * 2 - 1) + "*" + new string('.', helper));
            }


            Console.WriteLine(new string('.', x/2) + "*" + new string('.', totalwidth-(x/2)*2 - 2) + "*" + new string('.', x/2));

            for (int i = x - 2; i > 0; i--)
            {
                helper = (totalwidth - i * 2 - 1) / 2;
                Console.WriteLine(new string('.', helper) + "*" + new string('.', i * 2 - 1) + "*" + new string('.', helper));
            }

            Console.WriteLine(new string('.', totalwidth / 2) + "*" + new string('.', totalwidth / 2));
        }
    }
}
