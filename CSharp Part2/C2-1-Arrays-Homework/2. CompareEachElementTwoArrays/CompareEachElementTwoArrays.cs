//Write a program that reads two arrays from the console and compares them element by element.


using System;

class Program
{
    static void Main()
    {
        Console.Write("Number of elements in each string ?  ");
        int size = int.Parse(Console.ReadLine());
        int[] first = new int[size];
        int[] second = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element " + (i + 1) + " of the first string? ");
            first[i] = int.Parse(Console.ReadLine());        
        }
        Console.WriteLine();
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element " + (i + 1) + " of the second string? ");
            second[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < size; i++)
        {
            if (first[i] > second[i])
            {
                Console.WriteLine("Elements "+(i+1)+"-------- "+first[i] +" > "+second[i]);
            }
            else if (first[i] < second[i])
            {
                Console.WriteLine("Elements " + (i + 1) + "-------- " + first[i] + " < " + second[i]);
            }
            else
            {
                Console.WriteLine("Elements " + (i + 1) + "-------- " + first[i] + " = " + second[i]);
            }
        }
    }
}

