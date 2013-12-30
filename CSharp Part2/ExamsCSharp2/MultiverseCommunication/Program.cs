using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MultiverseCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers13 = new int[input.Length / 3];
            for (int i = 0; i < input.Length/3; i++)
            {
                string number = input[i * 3 + 0].ToString() + input[i * 3 + 1].ToString() + input[i * 3 + 2].ToString();
                switch (number)
                {
                    case "CHU": numbers13[i] = 0; break;
                    case "TEL": numbers13[i] = 1; break;
                    case "OFT": numbers13[i] = 2; break;
                    case "IVA": numbers13[i] = 3; break;
                    case "EMY": numbers13[i] = 4; break;
                    case "VNB": numbers13[i] = 5; break;
                    case "POQ": numbers13[i] = 6; break;
                    case "ERI": numbers13[i] = 7; break;
                    case "CAD": numbers13[i] = 8; break;
                    case "K-A": numbers13[i] = 9; break;
                    case "IIA": numbers13[i] = 10; break;
                    case "YLO": numbers13[i] = 11; break;
                    case "PLA": numbers13[i] = 12; break;
                }
            }
            BigInteger answer = 0;
            for (int i = 0; i < input.Length/3; i++)
            {
                answer = answer + numbers13[input.Length / 3 - 1 - i] * (BigInteger)Math.Pow(13, i);
            }
            Console.WriteLine(answer);
        }
    }
}