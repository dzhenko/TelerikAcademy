using System;

class Program
{
    static void Main()
    {
        int width = Convert.ToInt32(Console.ReadLine());
        int centre = (width + 1) / 2;
        for (int i = 1; i < centre; i++)
        {       
            Console.Write(new string('.',i-1) + "\\");
            Console.Write(new string('.', centre - i - 1));        
            Console.Write("|");           
            Console.Write(new string('.', centre - i - 1) + "/");
            Console.Write(new string('.', i - 1) );            
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', centre - 1) + "*" + new string('-', centre - 1));
        for (int i = 1; i < centre; i++)
        {
            Console.Write(new string('.', centre - i - 1) + "/");
            Console.Write(new string('.', i - 1));
            Console.Write("|");
            Console.Write(new string('.', i - 1) + "\\");
            Console.Write(new string('.', centre - i - 1));
           
            
            Console.WriteLine();
        }
    }
}

