//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDec   
{
    static void Main()
    {
        string input = Console.ReadLine();
        int size = input.Length;
        int answer = 0;
        int digit = 0;
        for (int i = 0; i < size; i++)
        {
            digit = int.Parse(input[i].ToString());
            answer = answer + digit * (int)Math.Pow(2, size - 1 - i);
        }
        Console.WriteLine(answer);
    }
}

