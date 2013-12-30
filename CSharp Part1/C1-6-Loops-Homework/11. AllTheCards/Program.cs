//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
//The cards should be printed with their English names. Use nested for loops and switch-case.


using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                switch (j)
                {
                    case 0: Console.Write("Two"  ); break;
                    case 1: Console.Write("Three"); break;
                    case 2: Console.Write("Four" ); break;
                    case 3: Console.Write("Five" ); break;
                    case 4: Console.Write("Six"  ); break;
                    case 5: Console.Write("Seven"); break;
                    case 6: Console.Write("Eight"); break;
                    case 7: Console.Write("Nine" ); break;
                    case 8: Console.Write("Ten"  ); break;
                    case 9: Console.Write("Jack" ); break;
                    case 10: Console.Write("Queen"); break;
                    case 11: Console.Write("King" ); break;
                    case 12: Console.Write("Ace"  ); break;
                }
                Console.Write(" of ");
                switch (i)
                {
                    case 0: Console.WriteLine( "hearts"); break;
                    case 1: Console.WriteLine("clubs"); break;
                    case 2: Console.WriteLine("diamonds"); break;
                    case 3: Console.WriteLine("spades"); break;
                }
            }
            Console.WriteLine();
        }
    }
}

