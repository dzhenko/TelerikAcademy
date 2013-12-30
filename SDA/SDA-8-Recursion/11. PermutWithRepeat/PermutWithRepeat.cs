//* Write a program to generate all permutations with repetitions of given multi-set. 
//For example the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
//{ 1, 3, 5, 5 }	{ 1, 5, 3, 5 }
//{ 1, 5, 5, 3 }	{ 3, 1, 5, 5 }
//{ 3, 5, 1, 5 }	{ 3, 5, 5, 1 }
//{ 5, 1, 3, 5 }	{ 5, 1, 5, 3 }
//{ 5, 3, 1, 5 }	{ 5, 3, 5, 1 }
//{ 5, 5, 1, 3 }	{ 5, 5, 3, 1 }
//Ensure your program efficiently avoids duplicated permutations. 
//Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.


using System;
using System.Collections.Generic;

class PermutWithRepeat
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int numberOfElements = int.Parse(Console.ReadLine());
        int[] multiset = new int[numberOfElements];
        bool[] used = new bool[numberOfElements];
        ReadElements(multiset);
        int[] answer = new int[numberOfElements];

        List<string> combinations = new List<string>();

        Permute(multiset, 0, answer, used, combinations);
    }

    private static void Permute(int[] multiset, int index, int[] answer, bool[] used , List<string> combinations)
    {
        if (index == multiset.Length)
        {
            ExecuteCombination(answer, combinations);
        }
        else
        {
            for (int i = 0; i < multiset.Length; i++)
            {
                if (!used[i])
                {
                    answer[index] = multiset[i];
                    used[i] = true;
                    Permute(multiset, index + 1, answer, used, combinations);
                    used[i] = false;
                }
            }
        }
    }

    private static void ExecuteCombination(int[] answer , List<string> combinations)
    {
        string currentCombo = null;
        for (int i = 0; i < answer.Length; i++)
			{
			    currentCombo = currentCombo + answer[i];
			}

        if (!combinations.Contains(currentCombo))
        {
            combinations.Add(currentCombo);
            PrintAnswer(answer);
        }
    }

    private static void PrintAnswer(int[] answer)
    {
        Console.Write(answer[0]);
        for (int i = 1; i < answer.Length; i++)
        {
            Console.Write(" " + answer[i]);
        }
        Console.WriteLine();
    }


    private static void ReadElements(int[] multiset)
    {
        for (int i = 0; i < multiset.Length; i++)
        {
            Console.Write("Enter element "+(i+1)+" : ");
            multiset[i] = int.Parse(Console.ReadLine());
        }
    }
}

