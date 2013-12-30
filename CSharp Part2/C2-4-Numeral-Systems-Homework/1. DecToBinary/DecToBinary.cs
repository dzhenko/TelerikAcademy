//Write a program to convert decimal numbers to their binary representation.


using System;

class DecToBinary
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        string answer = null;

        while (input != 0)
        {
            answer = (input % 2) + answer;
            input = input / 2;
        }
        Console.WriteLine(answer);
    }
}

