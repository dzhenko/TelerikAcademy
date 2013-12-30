//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).


using System;

class SignedToBinary
{
    static void Main()
    {
        int maxNum = (int)Math.Pow(2, 15);
        int input = int.Parse(Console.ReadLine());
        while (input > maxNum)
        {
            Console.WriteLine(maxNum + "is the max number ! Enter your number again ! ");
            input = int.Parse(Console.ReadLine());
        }

        bool minus = false;
        if (input < 0)
        {
            minus = true;
            input = maxNum + input;
        }
        string answer = null;

        while (input != 0)
        {
            answer = (input % 2) + answer;
            input = input / 2;
        }
        if (minus)
        {
            Console.Write(1);
        }
        else
        {
            Console.Write(0);
        }
        Console.WriteLine(answer);
        
    }
}

