//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class StringOf20Chars
{
    static void Main(string[] args)
    {
        StringBuilder answer = new StringBuilder();
        string input = Console.ReadLine();
        int counter = 0;
        while (counter < input.Length && counter < 21)
        {
            answer.Append(input[counter]);
            counter++;
        }
        if (answer.Length < 21)
        {
            answer.Append(new string('*',20 - answer.Length));
        }
        Console.WriteLine(answer.ToString());
        //Console.WriteLine(answer.Length);//just to check
    }
}

