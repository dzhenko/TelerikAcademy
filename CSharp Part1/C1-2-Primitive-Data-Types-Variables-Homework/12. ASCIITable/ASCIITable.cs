using System;
using System.Text; //For Unicode encoding of the console output

class ASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode; 
        for (int i = 0; i < 256; i++)
        {
            char symb = (char)i;
            Console.WriteLine("The character -> " + symb + " has a code -> " + i.ToString());
        }
    }
}

