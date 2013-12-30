//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).


using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<char> box = new Stack<char>();
        string input = Console.ReadLine();
        bool correct = true;
        int countOpen = 0;
        int countClosed = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                box.Push('(');
                countOpen++;
            }
            if (input[i] == ')')
            {
                countClosed++;
                if (box.Count == 0)
                {
                    correct = false;
                }
                else if (box.Pop() != '(')
                {
                    correct = false;
                }
            }
        }
        if (countOpen!=countClosed)
        {
            correct = false;
        }
        string answer = "Correct";
        if (!correct)
        {
            answer = "NOT correct";
        }
        Console.WriteLine("This expression is {0}",answer);
    }
}