using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/// <summary>
/// Тествам 3 начина - 2 с речник и един с HashSet - оказва се (за ~11 000 000 елемента, че варианта с речник си е най-бърз когато отговора остане в IEnumerable). Когато се обърне в лист отговора, начина с HashSet се оказва малко по-бърз.
/// </summary>
// Write a program that removes from given sequence all numbers that occur odd number of times. Example:
// {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}

public class Program
{
    public static void Main()
    {
        var input = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        for (int i = 0; i < 20; i++)
        {
            input.AddRange(input);
        }

        Console.WriteLine("Testing with {0} elements:", input.Count);

        HashSetWay(input);

        FirstDictWay(input);

        SecondDictWay(input);
    }

    public static void HashSetWay(IList<int> input)
    {
        Console.WriteLine("Hash set");
        var sw = new Stopwatch();
        sw.Start();
        var table = new HashSet<int>();

        foreach (var num in input)
        {
            if (table.Contains(num))
            {
                table.Remove(num);
            }
            else
            {
                table.Add(num);
            }
        }

        Console.WriteLine(sw.ElapsedTicks + " hash set formed");

        var answer = input.Where(x => table.Contains(x));
        Console.WriteLine(sw.ElapsedTicks + " answer formed");

        answer = answer.ToList();
        Console.WriteLine(sw.ElapsedTicks + " answer to list");
    }

    public static void FirstDictWay(IList<int> input)
    {
        Console.WriteLine("Standard dict way");
        var sw = new Stopwatch();
        sw.Start();

        var dict = new Dictionary<int, int>();

        for (int i = 0; i < input.Count; i++)
        {
            if (!dict.ContainsKey(input[i]))
            {
                dict.Add(input[i], 1);
            }
            else
            {
                dict[input[i]]++;
            }
        }
        Console.WriteLine(sw.ElapsedTicks + " dict formed");

        var answer = input.Where(x => dict[x] % 2 == 0);
        Console.WriteLine(sw.ElapsedTicks + " answer formed");

        answer = answer.ToList();
        Console.WriteLine(sw.ElapsedTicks + " answer to list");
    }

    public static void SecondDictWay(IList<int> input)
    {
        Console.WriteLine("Dict with lambda");
        var sw = new Stopwatch();
        sw.Start();

        var dict = input.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
        Console.WriteLine(sw.ElapsedTicks + " dict formed");

        var answer = input.Where(x => dict[x] % 2 == 0);
        Console.WriteLine(sw.ElapsedTicks + " answer formed");

        answer = answer.ToList();
        Console.WriteLine(sw.ElapsedTicks + " answer to list");
    }
}
