//Write a program for generating and printing all subsets of k strings from given set of strings.
//	Example: s = {test, rock, fun}, k=2
//	(test rock),  (test fun),  (rock fun)



using System;

public class AllSubsetsOfKStrings
{
    static void Main()
    {
        //Console.Write("Enter n: ");
        //int n = int.Parse(Console.ReadLine());
        //Console.Write("Enter k: ");
        //int k = int.Parse(Console.ReadLine());
        //string[] set = new string[n];
        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write("Enter {0} element: ",i+1);
        //    set[i] = Console.ReadLine();
        //}
        int n = 3;
        int k = 2;

        var set = new string[] { "test", "rock", "fun" };

        string[] stringToPrint = new string[k];

        Combos(0, n,0, set, stringToPrint);
    }

    private static void Combos(int index, int n,int start, string[] set, string[] stringToPrint)
    {
        if (index >= stringToPrint.Length)
        {
            Console.WriteLine("( " + string.Join(",",stringToPrint) + " )");
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
}
