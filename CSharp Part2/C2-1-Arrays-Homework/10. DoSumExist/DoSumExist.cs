//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	


using System;

class DoSumExist
{
    static void Main(string[] args)
    {
        Console.Write("The wanted Sum ( S ) ?  ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Number of elements in the array ( N ) ?  ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int sum;
        int counter;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? ");
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            sum = 0;
            counter = 1;
            for (int j = i; j < n; j++)
            {
                if (sum == s)
                {
                    Console.Write("S = "+s+" { ");
                    Console.Write(array[i]);
                    for (int z = 0; z < counter - 2; z++)
                    {                       
                        Console.Write(", ");
                        Console.Write(array[i + z +1]);
                    }
                    Console.WriteLine(" }");
                    Environment.Exit(0); // my new favorite thing :)
                }
                else if (sum > s)
                {
                    break;
                }
                else
                {
                    sum = sum + array[j];
                    counter = counter + 1;
                }
            }
        }
        Console.WriteLine("Immposible to find such sum");
    }
}

