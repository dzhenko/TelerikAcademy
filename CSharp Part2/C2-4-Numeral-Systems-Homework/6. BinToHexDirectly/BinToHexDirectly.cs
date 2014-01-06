//Write a program to convert binary numbers to hexadecimal numbers (directly).


using System;
using System.Text;

class BinToHexDirectly
{
    static void Main()
    {
        Console.WriteLine("Enter the binary number" );
        string input = Console.ReadLine();
        input = input.PadLeft(64,'0');
        int[] inputinfour = new int[16];
        for (int i = 0; i < 16; i++)
        {
            inputinfour[i] = int.Parse(input[i * 4].ToString() + input[i * 4 + 1].ToString() + input[i * 4 + 2].ToString() + input[i * 4 + 3].ToString());
        }
        StringBuilder final = new StringBuilder();
        foreach (int combo in inputinfour)
        {
            switch (combo)
            {
                case 0: final.Append("0"); break;
                case 1: final.Append("1"); break;
                case 10: final.Append("2"); break;
                case 11: final.Append("3"); break;
                case 100: final.Append("4"); break;
                case 101: final.Append("5"); break;
                case 110: final.Append("6"); break;
                case 111: final.Append("7"); break;
                case 1000: final.Append("8"); break;
                case 1001: final.Append("9"); break;
                case 1010: final.Append("A"); break;
                case 1011: final.Append("B"); break;
                case 1100: final.Append("C"); break;
                case 1101: final.Append("D"); break;
                case 1110: final.Append("E"); break;
                case 1111: final.Append("F"); break;        
                default: Console.WriteLine("ERROR!"); break;
            }
        }
        string answer = final.ToString();
        answer = answer.TrimStart('0');
        Console.WriteLine(answer);
    }
}


        