namespace PrintStatistics
{
    using System;

    public class StatisticsPrinter
    {
        // the task states that this is not a static method
        public void PrintStatistics(double[] sourceArray)
        {
            double minElement = this.FindMinElement(sourceArray);
            double maxElement = this.FindMaxElement(sourceArray);
            double averageOfElements = this.FindAverageOfElements(sourceArray);

            this.PrintInformation(minElement, maxElement, averageOfElements);
        }

        private double FindAverageOfElements(double[] sourceArray)
        {
            double sumOfAllElements = 0;

            for (int i = 0; i < sourceArray.Length; i++)
            {
                sumOfAllElements += sourceArray[i];   
            }

            double averageOfElements = sumOfAllElements / sourceArray.Length;
            return averageOfElements;
        }

        private double FindMaxElement(double[] sourceArray)
        {
            double maxElement = sourceArray[0];

            for (int i = 1; i < sourceArray.Length; i++)
            {
                if (maxElement < sourceArray[i])
                {
                    maxElement = sourceArray[i];
                }
            }

            return maxElement;
        }

        private double FindMinElement(double[] sourceArray)
        {
            double minElement = sourceArray[0];

            for (int i = 1; i < sourceArray.Length; i++)
            {
                if (minElement > sourceArray[i])
                {
                    minElement = sourceArray[i];
                }
            }

            return minElement;
        }

        private void PrintInformation(double minElement, double maxElement, double averageOfElements)
        {
            Console.Write("Minimum element is: ");
            Console.WriteLine(minElement);

            Console.Write("Maximum element is: ");
            Console.WriteLine(maxElement);

            Console.Write("Average of elements is: ");
            Console.WriteLine(averageOfElements);
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
