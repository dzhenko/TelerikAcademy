//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
//Use variable number of arguments.
//* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;

class GenericOperations
{
    public static T Min<T>(params T[] array)
    {
        dynamic min = array[0];

        foreach (var item in array)
        {
            if (min > item)
            {
                min = item;
            }
        }
        return min;
    }

    public static T Max<T>(params T[] array)
    {
        dynamic max = array[0];

        foreach (var item in array)
        {
            if (max < item)
            {
                max = item;
            }
        }
        return max;
    }

    public static T Average<T>(params T[] array)
    {
        return (T)(Sum<T>(array) / (dynamic)array.Length);
    }

    public static T Sum<T>(params T[] array)
    {
        dynamic sum = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            sum += array[i];
        }
        return (T)sum;
    }

    public static T Product<T>(params T[] array)
    {
        dynamic product = 1;

        foreach (var item in array)
        {
            product *= item;
        }
        return (T)product;
    }

    public static void Main()
    {
        byte[] byteArr = new byte[] { 1, 2, 3, 4, 5, 6 };
        int[] intArr = new int[] { 1, 2, 3, 4 };
        float[] floatArr = new float[] { 1.23f, 1.33f, 4.23f, 7.22f };
        decimal[] decArr = new decimal[] { 1.28m, 1.44m, 4.23m, 7.12m };

        Console.WriteLine(Sum(byteArr));
        Console.WriteLine(Sum(intArr));
        Console.WriteLine(Sum(floatArr));
        Console.WriteLine(Sum(decArr));

        Console.WriteLine();

        Console.WriteLine(Average(byteArr));
        Console.WriteLine(Average(intArr));
        Console.WriteLine(Average(floatArr));
        Console.WriteLine(Average(decArr));

        Console.WriteLine();

        Console.WriteLine(Min(byteArr));
        Console.WriteLine(Min(intArr));
        Console.WriteLine(Min(floatArr));
        Console.WriteLine(Min(decArr));

        Console.WriteLine();

        Console.WriteLine(Max(byteArr));
        Console.WriteLine(Max(intArr));
        Console.WriteLine(Max(floatArr));
        Console.WriteLine(Max(decArr));

        Console.WriteLine();

        Console.WriteLine(Product(byteArr));
        Console.WriteLine(Product(intArr));
        Console.WriteLine(Product(floatArr));
        Console.WriteLine(Product(decArr));
    }
}


