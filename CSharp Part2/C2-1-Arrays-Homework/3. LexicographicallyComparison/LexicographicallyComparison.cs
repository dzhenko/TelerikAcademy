//Write a program that compares two char arrays lexicographically (letter by letter).


using System;

class LexicographicallyComparison
{
    static void Main()
    {
        Console.Write("Enter the first string : ");
        string input1 = Console.ReadLine().ToLower(); //dont want the size of the letter to matter

        Console.Write("Enter the second string : ");
        string input2 = Console.ReadLine().ToLower();

        int smallerString = Math.Min(input1.Length, input2.Length);

        for (int i = 0; i < smallerString; i++)
        {
            if (input1[i] < input2[i])
            {
                Console.WriteLine("The FIRST array is lexicographically smaller");
                return;
            }
            else if (input1[i] > input2[i])
            {
                Console.WriteLine("The SECOND array is lexicographically smaller");
                return;
            }
        }

        //if we are here so up to now the two arrays were the same

        if (input1.Length > input2.Length)
        {
            Console.WriteLine("The SECOND array is lexicographically smaller (it has fewer letters)");
        }
        else if ((input1.Length <input2.Length))
        {
            Console.WriteLine("The FIRST array is lexicographically smaller (it has fewer letters)");
        }
        else
        {
            Console.WriteLine("The two arrays are exactly the same");
        }
    }
}

