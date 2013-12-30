using System;
using System.Text; //For Unicode encoding of the console output

class Copyright
{
    static void Main()
    {;
        Console.OutputEncoding = Encoding.Unicode;
        char copyrightSymb = '\u00a9';  //this is the char for the copyright symbol
        int numberOfSymb = 9;           //number of symbols to be used (Must be a number that can be squareroot-ed - 1 4 9 16 25 etc.. )
        int width = (int)Math.Sqrt(numberOfSymb);
        for (int i = 1; i <= width; i++)
        {
            Console.Write(new string (' ',width-i));
            Console.Write(new string (copyrightSymb,i*2-1));
            Console.Write(new string (' ',width-i));
            Console.WriteLine();
        }
    }
}

