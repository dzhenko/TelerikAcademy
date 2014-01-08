//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<char> box = new Stack<char>();
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                box.Push('(');
            }
            if (input[i] == ')')
            {
                if (box.Count == 0)
                {
                    Console.WriteLine("Not correct!");
                    return;
                }
                box.Pop();
            }
        }
        if (box.Count == 0)
        {
            Console.WriteLine("correct!");
        }
        else
        {
            Console.WriteLine("Not correct!");
        }
    }
}