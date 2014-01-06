using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static void Main()
    {
        //read data
        int[] inputCoordXYZ = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

        string MoveRed = ProcessMovementNumbers(Console.ReadLine());
        string MoveBlue = ProcessMovementNumbers(Console.ReadLine());


    }

    private static string ProcessMovementNumbers(string original)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder currNumsOfOperations = new StringBuilder();
        for (int i = 0; i < original.Length; i++)
        {
            if (char.IsDigit(original[i]))
            {
                currNumsOfOperations.Append(original[i]);
            }
            else
            {
                if (currNumsOfOperations.Length == 0)
                {
                    sb.Append(original[i]);
                }
                else
                {
                    int times = int.Parse(currNumsOfOperations.ToString());
                    currNumsOfOperations.Clear();
                    for (int j = 0; j < times; j++)
                    {
                        sb.Append(original[i]);
                    }
                }
            }
        }
        return sb.ToString();
    }
}

