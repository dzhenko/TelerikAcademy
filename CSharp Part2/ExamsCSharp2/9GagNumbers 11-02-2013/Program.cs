using System;                                                    
using System.Collections.Generic;                                
using System.Linq;                                               
using System.Text;
using System.Numerics;                                                           
namespace _9GagNumbers_11_02_2013                                
{                                                                
    class Program                                                
    {                                                            
        static int GetDigit(string input)                        
        {
            switch (input)
            {
                case "-!": return 0;
                case "**": return 1;
                case "!!!": return 2;
                case "&&": return 3;
                case "&-": return 4;
                case "!-": return 5;
                case "*!!!": return 6;
                case "&*!": return 7;
                case "!!**!-": return 8;
                default: return 9;
            }
        }
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            List<int> realDigits = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);
                int currDig = GetDigit(sb.ToString());
                if (currDig != 9)
                {
                    realDigits.Add(currDig);
                    sb.Clear();
                }
            }
            BigInteger answer = 0;
            int pow = 0;
            for (int i = realDigits.Count - 1; i >= 0; i--)
            {
                BigInteger currAdder = 1;
                for (int p = 0; p < pow; p++)
                {
                    currAdder = currAdder * 9;
                }
                currAdder = currAdder * realDigits[i];
                answer = answer + currAdder;
                pow++;
            }

            Console.WriteLine(answer);
        }
    }
}
