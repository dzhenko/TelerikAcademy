using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermuteWithRepetitionsGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 3, 5, 5 };

            Permuter.GeneratePermutationsWithRepetitions<int>(list, x => Console.WriteLine(string.Join(", ",x)));
        }
    }
}
