using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoInstructions
{
    class Program
    {
        static string Answer1(char digit)
        {
            string answer = null;
            switch (digit)
            {
                case '0': answer = null; break;
                case '1': answer = "6"; break;
                case '2': answer = "66"; break;
                case '3': answer = "666"; break;
            }
            return answer;
        }

        static string Answer2(char digit)
        {
            string answer = null;
            switch (digit)
            {
                case '0': answer = null; break;
                case '1': answer = "4"; break;
                case '2': answer = "44"; break;
                case '3': answer = "444"; break;
                case '4': answer = "45"; break;
                case '5': answer = "5"; break;
                case '6': answer = "54"; break;
                case '7': answer = "544"; break;
                case '8': answer = "5444"; break;
                case '9': answer = "46"; break;
            }
            return answer;
        }

        static string Answer3(char digit)
        {
            string answer = null;
            switch (digit)
            {
                case '0': answer = null; break;
                case '1': answer = "2"; break;
                case '2': answer = "22"; break;
                case '3': answer = "222"; break;
                case '4': answer = "23"; break;
                case '5': answer = "3"; break;
                case '6': answer = "32"; break;
                case '7': answer = "322"; break;
                case '8': answer = "3222"; break;
                case '9': answer = "24"; break;
            }
            return answer;
        }

        static string Answer4(char digit)
        {
            string answer = null;
            switch (digit)
            {
                case '0': answer = null; break;
                case '1': answer = "0"; break;
                case '2': answer = "00"; break;
                case '3': answer = "000"; break;
                case '4': answer = "01"; break;
                case '5': answer = "1"; break;
                case '6': answer = "10"; break;
                case '7': answer = "100"; break;
                case '8': answer = "1000"; break;
                case '9': answer = "02"; break;
            }
            return answer;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string answer = null;
            if (input.Length == 4)
            {
                answer = Answer1(input[0]) + Answer2(input[1]) + Answer3(input[2]) + Answer4(input[3]);
            }
            else if (input.Length == 3)
            {
                answer = Answer2(input[0]) + Answer3(input[1]) + Answer4(input[2]);
            }
            else if (input.Length == 2)
            {
                answer = Answer3(input[0]) + Answer4(input[1]);
            }
            else if (input.Length == 1)
            {
                answer = Answer4(input[0]);
            }
            Console.WriteLine(answer);
        }
    }
}
