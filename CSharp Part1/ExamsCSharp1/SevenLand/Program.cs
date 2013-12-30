using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenLand
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringinput = Console.ReadLine();
            int input = int.Parse(stringinput);

            int tensys = 0;

            for (int i = 0; i < stringinput.Length; i++)
            {
                tensys = tensys + int.Parse((stringinput[stringinput.Length - 1 - i].ToString())) * (int)Math.Pow(7, i);
            }
            tensys++;

            string answer = null;
            while (true)
            {
                answer = (tensys % 7).ToString() + answer;
                tensys = tensys / 7;
                if (tensys==0)
                {
                    break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
