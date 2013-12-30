//Write a program that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.


using System;

class MaxSequenceOfEqElements
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
        int counter;
        int answer = 0;
        int max = 0;
        for (int i = 0; i < size; i++)
        {
            counter = 0;
            for (int j = 0+i; j < size; j++)
            {
                if (array[j] == array[i])
                {
                    counter = counter + 1;
                }
                else
                {
                    break;
                }
            }
            if (counter > max)
            {
                max = counter;
                answer = array[i];
            }
        }
        Console.WriteLine("answer is " + max+ " times - the element is "+answer);
    }
}

