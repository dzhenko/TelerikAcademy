//Write a method that reverses the digits of given decimal number. Example: 256  652


using System;

class DigitReverser
{
    static int DigitReverse(int input)
    {
        string number = input.ToString();
        string output = null;
        for (int i = 0; i < number.Length; i++)
        {
            output = output + number[number.Length - 1 - i];
        }
        return int.Parse(output);
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        int answer = DigitReverse(n);
        Console.WriteLine(answer);
    }
}