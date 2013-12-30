using System;

class Program
{
    static void Main()
    {
        string entry = Console.ReadLine();
        string final = ReverseStringWords(entry);
        Console.WriteLine(final);
    }

    private static string ReverseStringWords(string entry)
    {
        string word = null;
        string final = null;
        int counter = 0;
        string[] answer = new string[99999];
        foreach (char letter in entry)
        {
            if (letter != ' ')
            {
                word = word + letter;

            }
            else
            {
                answer[counter] = word;
                counter++;
                word = null;
            }

        }
        final = word;
        for (int i = counter - 1; i >= 0; i--)
        {
            final = final + " " + answer[i];
        }
        return final;
    }
}

