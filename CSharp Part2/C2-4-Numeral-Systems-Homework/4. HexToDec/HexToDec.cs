//Write a program to convert hexadecimal numbers to their decimal representation.


using System;

class HexToDec
{
    static void Main()
    {
        string input = Console.ReadLine();
        bool minus = false;
        int answer = 0;
        if (input[0] == '-')
        {
            input = input.TrimStart('-');           
            minus = true;
        }
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[input.Length - 1 - i])
            {
                case '0': answer = answer + 0 ; break;
                case '1': answer = answer + 1*(int)Math.Pow(16,i); break;
                case '2': answer = answer + 2*(int)Math.Pow(16,i); break;
                case '3': answer = answer + 3*(int)Math.Pow(16,i); break;
                case '4': answer = answer + 4*(int)Math.Pow(16,i); break;
                case '5': answer = answer + 5*(int)Math.Pow(16,i); break;
                case '6': answer = answer + 6*(int)Math.Pow(16,i); break;
                case '7': answer = answer + 7*(int)Math.Pow(16,i); break;
                case '8': answer = answer + 8*(int)Math.Pow(16,i); break;
                case '9': answer = answer + 9*(int)Math.Pow(16,i); break;
                case 'A': answer = answer + 10*(int)Math.Pow(16,i); break;
                case 'B': answer = answer + 11*(int)Math.Pow(16,i); break;
                case 'C': answer = answer + 12*(int)Math.Pow(16,i); break;
                case 'D': answer = answer + 13*(int)Math.Pow(16,i); break;
                case 'E': answer = answer + 14*(int)Math.Pow(16,i); break;
                case 'F': answer = answer + 15*(int)Math.Pow(16,i); break;
                default: Console.WriteLine("Invalid input - only CAPITAL letters ! ");
                    Environment.Exit(0); break;
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

