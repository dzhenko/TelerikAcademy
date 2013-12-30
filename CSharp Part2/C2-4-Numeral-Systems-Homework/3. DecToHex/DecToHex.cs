//Write a program to convert decimal numbers to their hexadecimal representation.


using System;

class DecToHex
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        string answer = null;
        bool minus = false;
        if (input < 0)
        {
            input = input * (-1);
            minus = true;
        }
        while (true)
        {
            if (input % 16 > 9)
            {
                switch (input % 16)
                {
                    case 10: answer = "A" + answer ; break;
                    case 11: answer = "B" + answer ; break;
                    case 12: answer = "C" + answer ; break;
                    case 13: answer = "D" + answer ; break;
                    case 14: answer = "E" + answer ; break;
                    case 15: answer = "F" + answer ; break;
                }
            }
            else
            {
                answer = input % 16 + answer;
            }         
            input = input / 16;
            if (input == 0)
            {
                break;
            }
        }
        Console.Write(answer);
        if (minus)
        {
            Console.Write("   NEGATIVE");
        }
        Console.WriteLine();
    }
}

