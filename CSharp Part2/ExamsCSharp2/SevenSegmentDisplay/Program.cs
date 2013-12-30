using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSegmentDisplay
{
    class Program
    {
        static readonly int[] originalDigits = new int[10] {126,48,109,121,51,91,95,112,127,123};
        static StringBuilder sb = new StringBuilder();
        static int sizeDigits;
        static List<string> finalAnswers = new List<string>();
        static int[] inputDigits;

        static void Main()
        {
            sizeDigits = int.Parse(Console.ReadLine());

            inputDigits = new int[sizeDigits];

            for (int i = 0; i < sizeDigits; i++)
            {
                inputDigits[i] = Convert.ToInt32(Console.ReadLine(), 2);
            }

            SolveWithRCRSN(0);

            Console.WriteLine(finalAnswers.Count);
            finalAnswers.Sort();

            foreach (var item in finalAnswers)
            {
                Console.WriteLine(item);
            }
        }

        private static void SolveWithRCRSN(int currDigit)
        {
            if (currDigit == sizeDigits)
            {
                sb.Clear();
                foreach (var item in inputDigits)
                {
                    sb.Append(Array.IndexOf(originalDigits,item));
                }
                finalAnswers.Add(sb.ToString());
                sb.Clear();
                return;
            }

            for (int i = 0; i < originalDigits.Length; i++)
            {
                int originalDig = inputDigits[currDigit];
                if ((inputDigits[currDigit] | originalDigits[i]) == originalDigits[i])
                {
                    inputDigits[currDigit] = inputDigits[currDigit] | originalDigits[i];
                    SolveWithRCRSN(currDigit + 1);
                    inputDigits[currDigit] = originalDig;
                }
            }
        }
    }
}
