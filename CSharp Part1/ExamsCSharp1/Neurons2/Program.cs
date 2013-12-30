using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();
            while (true)
            {
                string inputer = Console.ReadLine();
                if (inputer=="-1")
                {
                    break;
                }
                input.Add(inputer);
            }

            List<long> output = new List<long>();

            foreach (string currLine in input)
            {
                long currNum10 = long.Parse(currLine);

                char[] currBinaryNum = Convert.ToString(currNum10, 2).PadLeft(32, '0').ToCharArray();
                
                for (int i = 0; i < currBinaryNum.Length; i++)
                {
                    if (currBinaryNum[i] == '1')
                    {
                        currBinaryNum[i] = '0';
                        if ((i + 1 < currBinaryNum.Length) && (currBinaryNum[i + 1] == '0'))
                        {
                            bool shouldIPrint = false;
                            int endBorder = 0;
                            for (int index = i + 1; index < currBinaryNum.Length; index++)
                            {
                                if (currBinaryNum[index] == '1')
                                {
                                    shouldIPrint = true;
                                    endBorder = index;
                                    break;
                                }
                            }
                            if (shouldIPrint)
                            {
                                for (int index = i + 1; index < endBorder; index++)
                                {
                                    currBinaryNum[index] = '1';
                                }
                                i = endBorder - 1;
                            }
                        }
                    }

                }

                long answer = Convert.ToInt64(new string(currBinaryNum), 2);
                output.Add(answer);

            }
            foreach (int answer in output)
            {
                Console.WriteLine(answer);
            }
        }
    }
}
