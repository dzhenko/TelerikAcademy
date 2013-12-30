//Write a program to convert binary numbers to hexadecimal numbers (directly).


using System;

class BinToHexDirectly
{
    static void Main()
    {
        Console.WriteLine("Enter the binary number" );
        string input = Console.ReadLine();
        input = input.PadLeft(32,'0');
        int[] inputinfour = new int[8];
        for (int i = 0; i < 8; i++)
        {
            inputinfour[i] = int.Parse(input[i * 4].ToString() + input[i * 4 + 1].ToString() + input[i * 4 + 2].ToString() + input[i * 4 + 3].ToString());
        }
        string final = null;
        foreach (int combo in inputinfour)
        {
            switch (combo)
            {
                case 0: final = final + "0"; break;
                case 1: final = final + "1"; break;
                case 10: final = final + "2"; break;
                case 11: final = final + "3"; break;
                case 100: final = final + "4"; break;
                case 101: final = final + "5"; break;
                case 110: final = final + "6"; break;
                case 111: final = final + "7"; break;
                case 1000: final = final + "8"; break;
                case 1001: final = final + "9"; break;
                case 1010: final = final + "A"; break;
                case 1011: final = final + "B"; break;
                case 1100: final = final + "C"; break;
                case 1101: final = final + "D"; break;
                case 1110: final = final + "E"; break;
                case 1111: final = final + "F"; break;        
                default: Console.WriteLine("ERROR!"); break;
            }
        }
        final = final.TrimStart('0');
        Console.WriteLine(final);
    }
}


        