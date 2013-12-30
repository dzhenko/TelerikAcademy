using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string allBits = Convert.ToString(n, 2).PadLeft(16, '0');
        string Bits = null;
        if (allBits.Length > 16)
	    {
            Bits = allBits.Substring(allBits.Length - 16);
	    }
        else
	    {
            Bits = allBits;
	    }
        

        string Line1 = null;
        string Line2 = null;
        string Line3 = null;
        string Line4 = null;

        if (Bits[0] == '1')
        {
            Line1 = ".#." ;
            Line2 = "##." ;
            Line3 = ".#." ;
            Line4 = ".#." ;
        }
        else
        {
            Line1 = "###";
            Line2 = "#.#";
            Line3 = "#.#";
            Line4 = "#.#";
        }

        for (int i = 1; i < Bits.Length; i++)
        {
            if (Bits[i] == '1')
            {
                Line1 =Line1 +"..#.";
                Line2 =Line2 +".##.";
                Line3 =Line3 +"..#.";
                Line4 =Line4 +"..#.";
            }
            else
            {
                Line1 =Line1+ ".###";
                Line2 =Line2+ ".#.#";
                Line3 =Line3+ ".#.#";
                Line4 =Line4+ ".#.#";
            }
        }
        string LastLine = "###.###.###.###.###.###.###.###.###.###.###.###.###.###.###.###";

        Console.WriteLine(Line1);
        Console.WriteLine(Line2);
        Console.WriteLine(Line3);
        Console.WriteLine(Line4);
        Console.WriteLine(LastLine);
    }
}

