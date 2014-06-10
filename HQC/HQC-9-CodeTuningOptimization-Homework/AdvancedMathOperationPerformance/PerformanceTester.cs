namespace AdvancedMathOperationPerformance
{
    using System;
    using System.Diagnostics;

    public class PerformanceTester
    {
        private const int IterationCount = 10000000;
        private static readonly Stopwatch StopWatch = new Stopwatch();

        public static void Main()
        {
            TestFloat();

            TestDouble();

            TestDecimal();
        }

        private static void TestFloat()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Float");

            float testFloat = 4.1f;
            double testResult = 2.0d;

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sqrt(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Square root");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Log(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Natural logarithm");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sin(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Sinus");

            Console.WriteLine("------------");
        }

        private static void TestDouble()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Double");

            double testFloat = 4.1d;
            double testResult = 2.0d;

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sqrt(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Square root");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Log(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Natural logarithm");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sin(testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Sinus");

            Console.WriteLine("------------");
        }

        private static void TestDecimal()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Decimal");

            decimal testFloat = 4.1m;
            double testResult = 2.0f;

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sqrt((double)testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Square root");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Log((double)testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Natural logarithm");

            StopWatch.Restart();
            for (int i = 0; i < IterationCount; i++)
            {
                testResult = Math.Sin((double)testFloat);
            }

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed + "  Sinus");

            Console.WriteLine("------------");
        }
    }
}
