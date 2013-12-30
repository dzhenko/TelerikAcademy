using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeDecoder_2011_2012_Test_Exam
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static int globalLineCounter = 0;
        static int stacker = 0;
        static void Main()
        {
            int[] rawFData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int online = rawFData[0];
            int onstack = rawFData[1];
            
            string originalGenome = Console.ReadLine();

            StringBuilder genomeLines = new StringBuilder();

            for (int i = 0; i < originalGenome.Length; i++)
            {
                if (char.IsDigit(originalGenome[i]))
                {
                    sb.Append(originalGenome[i]);
                }
                else
                {
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        genomeLines.Append(originalGenome[i]);
                    }
                    else
                    {
                        for (int j = 0; j < int.Parse(sb.ToString()); j++)
                        {
                            genomeLines.Append(originalGenome[i]);
                        }
                        sb.Clear();
                    }
                }
            }
            string allGenomeLines = genomeLines.ToString();
            int linesNeeded = (int)Math.Ceiling(((decimal)allGenomeLines.Length) / online);

            int liner = 0;
            sb.Clear();
            MakeNewLineZero(linesNeeded);
            sb.Append(allGenomeLines[0]);
            for (int i = 1; i < allGenomeLines.Length; i++)
            {
                liner++;
                stacker++;
                if (liner == online)
                {
                    liner = 0;
                    MakeNewLine(linesNeeded);
                    stacker = 0;
                }
                if (stacker == onstack)
                {
                    stacker = 0;
                    sb.Append(" ");
                }
                sb.Append(allGenomeLines[i]);
            }
            Console.Write(sb.ToString());
            if (onstack == 1 && online != 1 && online != 2)
            {
                Console.Write(" ");
            }
        }

        private static void MakeNewLine(int linesNeeded)
        {
            sb.AppendLine();
            globalLineCounter++;
            int spacesneeded = linesNeeded.ToString().Length - globalLineCounter.ToString().Length;
            for (int i = 0; i < spacesneeded; i++)
            {
                sb.Append(" ");
            }
            sb.Append(globalLineCounter);

            sb.Append(" ");
        }

        private static void MakeNewLineZero(int linesNeeded)
        {
            globalLineCounter++;
            int spacesneeded = linesNeeded.ToString().Length - globalLineCounter.ToString().Length;
            for (int i = 0; i < spacesneeded; i++)
            {
                sb.Append(" ");
            }
            sb.Append(globalLineCounter);

            sb.Append(" ");
        }
    }
}
