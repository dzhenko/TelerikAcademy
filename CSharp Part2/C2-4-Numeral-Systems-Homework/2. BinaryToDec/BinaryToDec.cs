//Write a program to convert binary numbers to their decimal representation.


using System;

class BinaryToDec   //first bit is always taken as the sighn bit
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int size = input.Length;
        int answer = 0;
        int digit = 0;
        for (int i = 1; i < size; i++)
        {
            digit = int.Parse(input[i].ToString());
            answer = answer + digit * (int)Math.Pow(2, size - 1 - i);
        }
        if (input[0] == '1')
        {
            Console.Write("-");
        }
        Console.WriteLine(answer);
    }
}

