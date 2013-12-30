using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//o	Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher
class Program
{
    static void Main()
    {
        //read And format data - chipher and message to decrypt are ready
        string rawInput = Console.ReadLine();
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        int indexOfFirstDigit = rawInput.Length;

        for (int i = rawInput.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(rawInput[i]))
            {
                indexOfFirstDigit--;
            }
            else
            {
                break;
            }
        }

        int chipherLength = int.Parse(rawInput.Substring(indexOfFirstDigit));
        rawInput = rawInput.Substring(0, indexOfFirstDigit);
        int timesToAppend = 0;
        for (int i = 0; i < rawInput.Length; i++)
        {
            if (char.IsDigit(rawInput[i]))
            {
                sb2.Append(rawInput[i]);
            }
            else
            {
                if (sb2.Length == 0)
                {
                    sb1.Append(rawInput[i]);
                }
                else
                {
                    timesToAppend = int.Parse(sb2.ToString());
                    sb2.Clear();
                    for (int z = 0; z < timesToAppend; z++)
                    {
                        sb1.Append(rawInput[i]);
                    }
                }
            }
        }
        rawInput = sb1.ToString();
        sb1.Clear();
        sb2.Clear();

        string chipher = rawInput.Substring(rawInput.Length - chipherLength);
        rawInput = rawInput.Substring(0, rawInput.Length - chipherLength);

        //chipher and rawInput proccessing
        if (chipher.Length <= rawInput.Length) // cycle is around the rawInput
        {
            int chipherIndex = -1;
            for (int i = 0; i < rawInput.Length; i++)
            {
                chipherIndex++;
                if (chipherIndex >= chipher.Length)
                {
                    chipherIndex = 0;
                }
                sb1.Append((char)(((rawInput[i] - 65) ^ (chipher[chipherIndex] - 65)) + 65));
            }
            Console.WriteLine(sb1.ToString());
        }
        else//cycle is around the chipher (it is longer) //TODO: Make a char array from string and change chars
        {
            char[] rawToChar = rawInput.ToCharArray();
            int rawIndex = -1;
            for (int i = 0; i < chipher.Length; i++)
            {
                rawIndex++;
                if (rawIndex >= rawInput.Length)
                {
                    rawIndex = 0;
                }
                rawToChar[rawIndex] = (char)(((rawToChar[rawIndex] - 65)^ (chipher[i]-65)) + 65);
            }
            Console.WriteLine(new string(rawToChar));
        }

    }
}

