//Write a program that finds the greatest of given 5 variables.


using System;

class GreatestOfFive
{
    static void Main()
    {
        double[] numbers = new double[5];;
        for (int i = 0; i < 5; i++)
        {
            numbers[i]= Convert.ToDouble(Console.ReadLine());
        }
        double max = numbers[0];
        for (int i = 0; i < 5; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        Console.Write("The Greatest of {0}, {1}, {2}, {3}, {4} is --->  ", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
        Console.WriteLine(max);
    }
}

