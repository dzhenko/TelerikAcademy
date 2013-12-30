//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)


using System;

class MostFrequentNumber
{
    static void Main()
    {
        Console.Write("Number of elements in the array ( N ) ?  ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];    
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? ");
            array[i] = int.Parse(Console.ReadLine());
        }
        int position=0;
        int counter;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            counter = 0;
            for (int j = 0; j < n; j++)
            {
                if (array[i] == array[j])
                {
                    counter++;
                }
            }
            if (max < counter)
            {
                max = counter;
                position = i;
            }    
        }
        if (max == 1)
        {
            Console.WriteLine("They are all unique");
        }
        else
        {
            Console.WriteLine(array[position] + " (" + max + " times)");
        }        
    }
}

