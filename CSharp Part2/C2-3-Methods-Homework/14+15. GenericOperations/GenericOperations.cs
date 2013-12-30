//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
//Use variable number of arguments.
//* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).


namespace _14_15.GenericOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface ICanDoSum<T>
    {
        T Add(T a, T b);
    }

    public struct IntSum : ICanDoSum<int>
    {
        public int Add ( int a , int b)
        {
            return a + b;
        }
    }

    public struct DecimalSum : ICanDoSum<decimal>
    {
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
    }

    public struct FloatSum : ICanDoSum<float>
    {
        public float Add(float a, float b)
        {
            return a + b;
        }
    }

    public struct ByteSum : ICanDoSum<byte>
    {
        public byte Add(byte a, byte b)
        {
            return (byte)(a + b);
        }
    }

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
            dynamic sum = 1;
            return Convert.ToDouble(sum) / array.Length;
        }

        public static T Sum<T>(params T[] array) where T : ICanDoSum<T>
        {
            T sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum = sum.Add(sum, array[i]);
            }
            return sum;
        }

        public static T Product<T>(params T[] array)
        {
            dynamic product = 1;

            foreach (var item in array)
            {
                product *= item;
            }
            return product;
        }

        public static void Main()
        {
            Console.WriteLine(Min(13.12,14,22.12421241242422,124,2));

            Console.WriteLine(Max(13.12,14,22.12421241242422,124,2));

            Console.WriteLine(Average(13.12,14,22.12421241242422,124,2));

            //Console.WriteLine(Sum(13.12,14,22.12421241242422,124,2));

            Console.WriteLine(Product(13.12,14,22.12421241242422,124,2));
        }
    }

}
