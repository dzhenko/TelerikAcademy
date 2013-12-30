using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anachi
{
    class Program
    {
        static void Main(string[] args)
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            if (lines == 1)
            {
                Console.WriteLine(input1);
                return;
            }

            int allnumbers = lines*2 - 1;
            int[] lettersInt = new int[allnumbers];

            lettersInt[0] = (int)input1 - 64;
            lettersInt[1] = (int)input2 - 64;

            for (int i = 2; i < allnumbers; i++)
            {
                lettersInt[i] = (lettersInt[i - 1] + lettersInt[i - 2]) % 26;
            }

            if (lines == 2)
            {
                Console.WriteLine((char)(lettersInt[0] + 64));
                Console.Write((char)(lettersInt[1] + 64));
                Console.WriteLine((char)(lettersInt[2] + 64));
                return;
            }

            Console.WriteLine((char)(lettersInt[0] + 64));
            Console.Write((char)(lettersInt[1] + 64));
            Console.WriteLine((char)(lettersInt[2] + 64));

            for (int i = 1; i <= lines-2; i++)
            {
                Console.Write((char)(lettersInt[1 + i*2] + 64));
                Console.Write(new string(' ',i));
                Console.WriteLine((char)(lettersInt[2 + i*2] + 64));
            }
        }
    }
}
