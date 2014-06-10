namespace SimpleMathOperationsPerformance
{
    using System;
    using System.Diagnostics;

    public class PerformanceTester
    {
        private const int IterationCount = 10000000;
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void Main()
        {
            TestInt();

            TestLong();

            TestFloat();

            TestDouble();

            TestDecimal();
        }

        private static void TestInt()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Int");

            int testInt1 = 4;
            int testInt2 = 2;
            int outInt = 2;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outInt = testInt1 + testInt2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Add");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outInt = testInt1 - testInt2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Substract");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outInt++;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment X++");
            outInt = 1;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                ++outInt;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment ++X");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outInt = testInt1 * testInt2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Multiply");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outInt = testInt1 / testInt2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Divide");

            Console.WriteLine("------------");
        }

        private static void TestLong()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Long");

            long testLong1 = 4;
            long testLong2 = 2;
            long outLong = 2;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outLong = testLong1 + testLong2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Add");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outLong = testLong1 - testLong2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Substract");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outLong++;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment X++");
            outLong = 1;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                ++outLong;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment ++X");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outLong = testLong1 * testLong2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Multiply");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outLong = testLong1 / testLong2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Divide");

            Console.WriteLine("------------");
        }

        private static void TestFloat()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Float");

            float testFloat1 = 4.1f;
            float testFloat2 = 2.05f;
            float outFloat = 2.0f;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outFloat = testFloat1 + testFloat2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Add");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outFloat = testFloat1 - testFloat2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Substract");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outFloat++;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment X++");
            outFloat = 1;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                ++outFloat;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment ++X");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outFloat = testFloat1 * testFloat2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Multiply");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outFloat = testFloat1 / testFloat2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Divide");

            Console.WriteLine("------------");
        }

        private static void TestDouble()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Double");

            double testDouble1 = 4.1d;
            double testDouble2 = 2.05d;
            double outDouble = 2.0d;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 + testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Add");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 - testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Substract");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble++;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment X++");
            outDouble = 1;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                ++outDouble;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment ++X");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 * testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Multiply");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 / testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Divide");

            Console.WriteLine("------------");
        }

        private static void TestDecimal()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Decimal");

            decimal testDouble1 = 4.1m;
            decimal testDouble2 = 2.05m;
            decimal outDouble = 2.0m;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 + testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Add");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 - testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Substract");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble++;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment X++");
            outDouble = 1;

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                ++outDouble;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Increment ++X");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 * testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Multiply");

            Stopwatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                outDouble = testDouble1 / testDouble2;
            }

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed + "  Divide");

            Console.WriteLine("------------");
        }
    }
}
