namespace RandomDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class RandomDataGeneratorTests
    {
        static void Main()
        {
            TestChance(10000000);

            TestStrings(10000000, 5, 20);
        }

        private static void TestChance(int count)
        {
            // check time
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                RandomDataGenerator.Instance.GetChance(50);
            }
            sw.Stop();
            
            // check percentage
            var trueCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (RandomDataGenerator.Instance.GetChance(50))
                {
                    trueCount++;
                }
            }

            Console.WriteLine("50 chance produces {0} times true - {1} % ({2} miliseconds)", trueCount,
                trueCount * 1.0 / count, sw.ElapsedMilliseconds);
        }

        private static void TestStrings(int count, int min, int max)
        {
            // check time
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                RandomDataGenerator.Instance.GetString(min, max);
            }
            sw.Stop();

            var hash = new HashSet<string>();

            for (int i = 0; i < 10000000; i++)
            {
                hash.Add(RandomDataGenerator.Instance.GetString(min, max));
            }

            Console.WriteLine("10000000 strings created - {0} of them are repeating ({1} miliseconds)", count - hash.Count, sw.ElapsedMilliseconds);
        }
    }
}
