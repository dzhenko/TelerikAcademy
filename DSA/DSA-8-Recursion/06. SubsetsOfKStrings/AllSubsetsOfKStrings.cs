//Write a program for generating and printing all subsets of k strings from given set of strings.
//	Example: s = {test, rock, fun}, k=2
//	(test rock),  (test fun),  (rock fun)



using System;

class AllSubsetsOfKStrings
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
            Console.Write("Enter {0} element: ",i+1);
            set[i] = Console.ReadLine();
        }

        string[] stringToPrint = new string[k];
        Combos(0, n,0, set, stringToPrint);
    }

    private static void Combos(int index, int n,int start, string[] set, string[] stringToPrint)
    {
        if (index >= stringToPrint.Length)
        {
            Print(stringToPrint);
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                stringToPrint[index] = set[i];
                Combos(index + 1, n,i + 1, set, stringToPrint);
            }
        }
    }

    private static void Print(string[] set)
    {
        Console.Write(set[0]);
        for (int i = 1; i < set.Length; i++)
        {
            Console.Write(" " + set[i]);
        }
        Console.WriteLine();
    }
}
