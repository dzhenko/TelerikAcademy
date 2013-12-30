using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Indeces
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader rarr = new StreamReader(@"..\..\input.txt");
            //
            //int n = int.Parse(rarr.ReadLine());
            //string[] rawData = rarr.ReadLine().Split();
            
            int n = int.Parse(Console.ReadLine());
            string[] rawData = Console.ReadLine().Split();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(rawData[i]);
            }
            StringBuilder answer = new StringBuilder();
            bool[] used = new bool[n];
            int indexToStepOn = 0;
            used[0] = true;
            answer.Append("0");

            while (true)
            {
                
                indexToStepOn = array[indexToStepOn];
                if (indexToStepOn < 0)
                {
                    break;
                }
                if (indexToStepOn >= n)
                {
                    break;
                }
                if (used[indexToStepOn])
                {
                    int indexToPut = answer.ToString().IndexOf(indexToStepOn.ToString() + " ");
                    if (indexToPut < 0)
                    {
                        indexToPut = 2;
                    }
                    string ToPrint = answer.ToString();
                    char[] reformer = ToPrint.ToCharArray();
                    if (indexToPut==0)
                    {
                        Console.WriteLine("(" + new string(reformer) + ")");
                        return;
                    }
                    else
                    {
                        reformer[indexToPut - 1] = '(';
                        Console.WriteLine(new string(reformer) + ")");
                        return;
                    }
                    
                }
                used[indexToStepOn] = true;
                answer.Append(" ");
                answer.Append(indexToStepOn);
            }

            Console.WriteLine(answer.ToString());

        }
    }
}
