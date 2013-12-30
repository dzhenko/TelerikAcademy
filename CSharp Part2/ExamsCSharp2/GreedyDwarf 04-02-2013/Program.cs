using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int absoluteMax = -10000;

    static void Main()
    {
        int[] valley = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int patternsCount = int.Parse(Console.ReadLine());
        int[][] patterns = new int[patternsCount][];
        for (int i = 0; i < patternsCount; i++)
        {
            patterns[i] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        }

        for (int i = 0; i < patternsCount; i++)
        {
            bool[] visited = new bool[valley.Length];
            int currSum = 0;
            int nextstep = 0;
            int counterForPatterns = 0;
            while (true)
            {
                if (nextstep >= 0 && nextstep < valley.Length && !visited[nextstep])
                {
                    currSum += valley[nextstep];
                    visited[nextstep] = true;
                    nextstep = nextstep + patterns[i][counterForPatterns];
                    counterForPatterns++;
                    counterForPatterns = counterForPatterns % patterns[i].Length;
                }
                else
                {
                    break;
                }
            }
            if (currSum > absoluteMax)
            {
                absoluteMax = currSum;
            }
        }
        Console.WriteLine(absoluteMax);
    }
}

