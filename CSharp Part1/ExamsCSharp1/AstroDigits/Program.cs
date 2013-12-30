using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int answer = 0;
            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '1')
                    {
                        answer = answer + 1;
                    }
                    else if (input[i] == '2')
                    {
                        answer = answer + 2;
                    }
                    else if (input[i] == '3')
                    {
                        answer = answer + 3;
                    }
                    else if (input[i] == '4')
                    {
                        answer = answer + 4;
                    }
                    else if (input[i] == '5')
                    {
                        answer = answer + 5;
                    }
                    else if (input[i] == '6')
                    {
                        answer = answer + 6;
                    }
                    else if (input[i] == '7')
                    {
                        answer = answer + 7;
                    }
                    else if (input[i] == '8')
                    {
                        answer = answer + 8;
                    }
                    else if (input[i] == '9')
                    {
                        answer = answer + 9;
                    }
                    else
                    {
                        answer = answer + 0;
                    }
                }
                if (answer < 10)
                {
                    Console.WriteLine(answer);
                    break;
                }
                input = answer.ToString();
                answer = 0;
            }
            
        }
    }
}
