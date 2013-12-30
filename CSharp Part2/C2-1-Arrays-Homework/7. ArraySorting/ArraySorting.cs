//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.


using System;

class ArraySorting
{
    static void Main(string[] args)
    {
        Console.Write("Number of elements in the array ( N ) ?  ");

        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];           
        
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? ");
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            int currMin = array[i];
            int curPos = i;
            for (int j = i; j < n; j++)
            {
                if (currMin  > array[j])
                {
                    currMin = array[j];
                    curPos = j;
                }
            }
            array[curPos] = array[i];
            array[i] = currMin;
        }


        for (int i = 0; i < n; i++)              
        {                                         
            Console.WriteLine(array[i]);       
        }
    }
}

