using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int tubes = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            long[] allTubes = new long[tubes];

            for (int i = 0; i < tubes; i++)
            {
                allTubes[i] = long.Parse(Console.ReadLine());

            }

            int maxtube = (int)allTubes.Max();
            long min = 0;
            long max = maxtube;
            long mid;
            int bestanswer = 0;
            while (min <= max)
            {
                mid = (min + max) / 2;
                int counter = 0;
                for (int i = 0; i < tubes; i++)
                {
                    counter += (int)(allTubes[i] / mid);
                }
                if (counter >= players)
                {
                    bestanswer = (int)mid;
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }

            }
            Console.WriteLine(bestanswer);
        }
    }
}