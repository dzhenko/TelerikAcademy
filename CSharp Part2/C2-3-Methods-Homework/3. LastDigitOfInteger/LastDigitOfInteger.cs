//Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".


using System;

class LastDigitOfInteger
{
    static string GetDigit(int input)
    {
        string digitAsWord = null;
        string inputAsString = input.ToString();
        switch (inputAsString[inputAsString.Length - 1])
	    {
		    case '0' : digitAsWord = "Zero" ;break;
            case '1': digitAsWord = "One"; break;
            case '2': digitAsWord = "Two"; break;
            case '3': digitAsWord = "Three"; break;
            case '4': digitAsWord = "Four"; break;
            case '5': digitAsWord = "Five"; break;
            case '6': digitAsWord = "Six"; break;
            case '7': digitAsWord = "Seven"; break;
            case '8': digitAsWord = "Eight"; break;
            case '9': digitAsWord = "Nine"; break;
    	}
        return digitAsWord;
    }

    static void Main()
    {
        Console.Write("Enter the number : ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine(GetDigit(input));
    }
}

