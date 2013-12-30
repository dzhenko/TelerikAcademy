//Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
//Print the obtained array on the console.


using System;

class TwentyIntegers
{
    static void Main()
    {
        int[] original = new int[20];
        int[] newints = new int[20];
        for (int i = 0; i < 20; i++)
        {
            original[i] = i + 1;
            newints[i] = original[i] * 5;
            Console.WriteLine(newints[i]);
        }
    }
}

