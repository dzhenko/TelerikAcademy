//Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).


using System;

class AllOrderedKSubNElem
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        string[] set = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter {0} element: ", i + 1);
            set[i] = Console.ReadLine();
        }

        string[] stringToPrint = new string[k];
        Combos(0, n, set, stringToPrint);
    }

    private static void Combos(int index, int n, string[] set, string[] stringToPrint)
    {
        if (index >= stringToPrint.Length)
        {
            Console.WriteLine(string.Join(" ",stringToPrint));
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                stringToPrint[index] = set[i];
                Combos(index + 1, n, set, stringToPrint);
            }
        }
    }
}
