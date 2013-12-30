//Write a program that reads a string from the console and prints all different letters 
//in the string along with information how many times each letter is found. 

namespace _21.EachLetterFound
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EachLetterFound
    {
        static void Main()
        {
            string source = Console.ReadLine();
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                chars.Add(i, 0);
            }
            for (char i = 'A'; i <= 'Z'; i++)
            {
                chars.Add(i, 0);
            }

            foreach (char curr in source)
            {
                if (chars.ContainsKey(curr))
                {
                    chars[curr]++;
                }
            }

            var ordered = chars.OrderBy(x => x.Key); //to sort by the letter
            foreach (var item in ordered)
            {
                if (item.Value != 0)
                {
                    Console.WriteLine("{0} -> {1} ", item.Key, item.Value);
                }
            }
        }
    }
}
