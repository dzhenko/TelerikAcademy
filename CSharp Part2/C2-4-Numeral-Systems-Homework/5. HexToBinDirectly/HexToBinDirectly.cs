//Write a program to convert hexadecimal numbers to binary numbers (directly).


using System;
using System.Text;

class HexToBinDirectly
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder answer = new StringBuilder();
        foreach (char letter in input)
        {
            switch (letter)
            {
                case '0': answer.Append("0000 "); break;
                case '1': answer.Append("0001 "); break;
                case '2': answer.Append("0010 "); break;
                case '3': answer.Append("0011 "); break;
                case '4': answer.Append("0100 "); break;
                case '5': answer.Append("0101 "); break;
                case '6': answer.Append("0110 "); break;
                case '7': answer.Append("0111 "); break;
                case '8': answer.Append("1000 "); break;
                case '9': answer.Append("1001 "); break;
                case 'A': answer.Append("1010 "); break;
                case 'B': answer.Append("1011 "); break;
                case 'C': answer.Append("1100 "); break;
                case 'D': answer.Append("1101 "); break;
                case 'E': answer.Append("1110 "); break;
                case 'F': answer.Append("1111 "); break;
                default: Console.WriteLine("ERROR!"); break;
            }
        }
        Console.WriteLine(answer);
    }
}

