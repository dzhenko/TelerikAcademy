//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.


using System;

class MaxIncreazingSequenceArray
{
    static void Main()
    {
        Console.Write("Number of elements in the array ?  ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? ");
            array[i] = int.Parse(Console.ReadLine());
        }
        int max = 0;
        int counter;
        int answer = array[0];
        for (int i = 0; i < size; i++)
        {
            counter = 1;
            for (int j = i; j < size; j++)
            {
                if ((j + 1 < size) && (array[j] == array[j + 1] - 1))
                {
                    counter = counter + 1;
                }
                else
                {
                    break;
                }
            }
            if (max < counter)
            {
                max = counter;
                answer = i;
            }
        }
        Console.WriteLine("There are maximum {0} increazing elements and they are: ",max);

        Console.Write(array[answer]);
        for (int i = answer + 1; i < answer + max; i++)
        {
            Console.Write(", ");
            Console.Write(array[i]);
        }
        Console.WriteLine();
    }
}

