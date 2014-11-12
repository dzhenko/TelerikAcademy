using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Girls
{
    class Program
    {
        static SortedSet<string> allCombos = new SortedSet<string>();

        static HashSet<string> skirtsCombos = new HashSet<string>();
        static HashSet<string> shirtsCombos = new HashSet<string>();

        static int shirts = 0;

        static void Main(string[] args)
        {
            shirts = int.Parse(Console.ReadLine());

            var skirts = Console.ReadLine();

            var girls = int.Parse(Console.ReadLine());

            var usedSkirts = new bool[skirts.Length];

            GenerateVariationsNoReps(0, new char[girls], skirts, usedSkirts);

            GetShirts(0, new int[girls], 0);

            foreach (var skirt in skirtsCombos)
            {
                foreach (var shirt in shirtsCombos)
                {
                    char[] all = new char[girls * 3 - 1];
                    for (int i = 0; i < girls - 1; i++)
                    {
                        all[i * 3] = shirt[i];
                        all[i * 3 + 1] = skirt[i];
                        all[i * 3 + 2] = '-';
                    }
                    all[all.Length - 2] = shirt[girls - 1];
                    all[all.Length - 1] = skirt[girls - 1];

                    allCombos.Add(new string(all));
                }
            }

            Console.WriteLine(allCombos.Count);

            foreach (var com in allCombos)
            {
                Console.WriteLine(com);
            }
        }

        static void GenerateVariationsNoReps(int index, char[] vector, string line, bool[] used)
        {
            if (index >= vector.Length)
            {
                skirtsCombos.Add(new string(vector));
            }
            else
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (!used[i])
                    {
                        var old = line[i];
                        used[i] = true;
                        vector[index] = line[i];

                        GenerateVariationsNoReps(index + 1, vector, line, used);

                        vector[index] = old;
                        used[i] = false;
                    }
                }
            }
        }

        static void GetShirts(int index, int[] vector, int startFrom)
        {
            if (index >= vector.Length)
            {
                shirtsCombos.Add(string.Join("", vector));
            }
            else
            {
                for (int i = startFrom; i < shirts; i++)
                {
                    vector[index] = i;

                    GetShirts(index + 1, vector, i + 1);
                }
            }
        }
    }
}
