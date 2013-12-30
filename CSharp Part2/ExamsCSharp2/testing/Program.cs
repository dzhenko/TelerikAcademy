using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb1 = new StringBuilder();
            string rawCriptedText = "aaabbcccdddde";

            int repeatingCounter = 0;
            char currChar = rawCriptedText[0];

            for (int i = 0; i < rawCriptedText.Length; i++)
            {
                if (currChar == rawCriptedText[i])
                {
                    repeatingCounter++;
                }
                else
                {
                    if (repeatingCounter == 1)
                    {
                        sb1.Append(currChar);
                        currChar = rawCriptedText[i];
                        repeatingCounter = 0;
                        i--;
                    }
                    else if (repeatingCounter == 2)
                    {
                        sb1.Append(currChar);
                        sb1.Append(currChar);
                        currChar = rawCriptedText[i];
                        repeatingCounter = 0;
                        i--;
                    }
                    else
                    {
                        sb1.Append(repeatingCounter);
                        repeatingCounter = 0;
                        sb1.Append(currChar);
                        currChar = rawCriptedText[i];
                        i--;
                    }
                }
            }
            Console.WriteLine(sb1);
        }
    }
}
