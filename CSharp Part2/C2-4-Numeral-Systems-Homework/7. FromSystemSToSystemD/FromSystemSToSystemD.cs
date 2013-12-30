//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).


using System;

class FromSystemSToSystemD
{
    static void Main(string[] args)
    {
        //input
        Console.WriteLine("Enter Source system - between 2 and 16 ");
        int systemS = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Destination system - between 2 and 16 ");
        int systemD = int.Parse(Console.ReadLine());
        if (systemS < 2 || systemS > 16 || systemD > 16 || systemD < 2)
        {
            Console.WriteLine("ERROR ! source and destination systems should be between 2 and 16");
            Environment.Exit(0);
        }
        Console.Write("Enter input");
        if (systemS == 2)
        {
            Console.Write( " !!!FIRST BIT WILL BE FOR THE SIGHN!!!");
        }

        Console.WriteLine();
        string input = Console.ReadLine();
        //minus
        bool minus = false;

        int answer = 0;
        if (input[0] == '-' && systemS > 2)
        {
            input = input.TrimStart('-');
            minus = true;
        }
        if (input[0] == '1' && systemS == 2)
        {
            input = input.Remove(0,1);
            minus = true;
        }
        // source system to 10
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[input.Length - 1 - i])
            {
                case '0': answer = answer + 0; break;
                case '1': answer = answer + 1 * (int)Math.Pow(systemS, i); break;
                case '2': answer = answer + 2 * (int)Math.Pow(systemS, i); break;
                case '3': answer = answer + 3 * (int)Math.Pow(systemS, i); break;
                case '4': answer = answer + 4 * (int)Math.Pow(systemS, i); break;
                case '5': answer = answer + 5 * (int)Math.Pow(systemS, i); break;
                case '6': answer = answer + 6 * (int)Math.Pow(systemS, i); break;
                case '7': answer = answer + 7 * (int)Math.Pow(systemS, i); break;
                case '8': answer = answer + 8 * (int)Math.Pow(systemS, i); break;
                case '9': answer = answer + 9 * (int)Math.Pow(systemS, i); break;
                case 'A': answer = answer + 10 * (int)Math.Pow(systemS, i); break;
                case 'B': answer = answer + 11 * (int)Math.Pow(systemS, i); break;
                case 'C': answer = answer + 12 * (int)Math.Pow(systemS, i); break;
                case 'D': answer = answer + 13 * (int)Math.Pow(systemS, i); break;
                case 'E': answer = answer + 14 * (int)Math.Pow(systemS, i); break;
                case 'F': answer = answer + 15 * (int)Math.Pow(systemS, i); break;
                default: Console.WriteLine("Invalid input - only CAPITAL letters !");
                    Environment.Exit(0); break;
            }
        }
        // TO DESTINATION SYSTEM
        string finalAnswer = null;
        int counter = -1;
        while (true)
        {
            counter++;
            switch (answer % systemD)
            {
                case 0:  finalAnswer = ( 0 ) +""+ finalAnswer; break;
                case 1:  finalAnswer = 1  + ""+finalAnswer; break;
                case 2:  finalAnswer = 2  + ""+finalAnswer; break;
                case 3:  finalAnswer = 3  + ""+finalAnswer; break;
                case 4:  finalAnswer = 4  + ""+finalAnswer; break;
                case 5:  finalAnswer = 5  + ""+finalAnswer; break;
                case 6:  finalAnswer = 6  + ""+finalAnswer; break;
                case 7:  finalAnswer = 7  + ""+finalAnswer; break;
                case 8:  finalAnswer = 8  + ""+finalAnswer; break;
                case 9:  finalAnswer = 9  + ""+finalAnswer; break;
                case 10: finalAnswer = "A"+""+finalAnswer; break;
                case 11: finalAnswer = "B"+""+finalAnswer; break;
                case 12: finalAnswer = "C"+""+finalAnswer; break;
                case 13: finalAnswer = "D"+""+finalAnswer; break;
                case 14: finalAnswer = "E"+""+finalAnswer; break;
                case 15: finalAnswer = "F"+""+finalAnswer; break;
            }
            answer = answer / systemD;
            if (answer == 0)
            {
                break;
            }
        }

        Console.Write(finalAnswer);
        if (minus)
        {
            Console.Write("  NEGATIVE");
        }
        Console.WriteLine();
    }
}

