using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace LargeCollectionProducts
{
    class Program
    {
        static void Main()
        {
            var allProducts = new OrderedMultiDictionary<decimal, string>(true);

            for (int i = 0; i < 500000; i++)
            {
                allProducts.Add(i, i.ToString());
            }

            var resultOutput = new StringBuilder();

            for (int i = 0; i < 10000; i++)
            {
                var result = allProducts.Range(i, true, i + 2000, true).Take(20);
                resultOutput.AppendLine(string.Join(", ", result.Select(x => x.Value)));
            }

            // kinda fast :)
            Console.Write(resultOutput.ToString());
        }
    }
}
