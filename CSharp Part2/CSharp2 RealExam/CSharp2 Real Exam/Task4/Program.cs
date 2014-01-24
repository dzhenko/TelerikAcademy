namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int[] codes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int numberOfLines = int.Parse(Console.ReadLine());

            Dictionary<int, char> onesToChar = new Dictionary<int, char>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();

                int key = int.Parse(line.Substring(1));

                onesToChar.Add(key, line[0]);
            }

            for (int i = 0; i < codes.Length; i++)
            {
                sb.Append(Convert.ToString(codes[i], 2).PadLeft(8,'0'));
            }
            int oneCounter = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '1')
                {
                    oneCounter++;
                }
                else if (oneCounter != 0)
                {
                    if (oneCounter <= onesToChar.Count)
                    {
                        Console.Write(onesToChar[oneCounter]);
                        oneCounter = 0;
                    }
                    else
                    {
                        int position = i;
                        int firstOnePosition = position - oneCounter;
                        int onesToUseFirst = 8 - firstOnePosition;
                        int onesToUseSecond = oneCounter - onesToUseFirst;
                        Console.Write(onesToChar[onesToUseFirst]);
                        Console.Write(onesToChar[onesToUseSecond]);
                        oneCounter = 0;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
