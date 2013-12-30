//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace DivisableBy3and7
{
    using System;
    using System.Linq;

    class DivisableBy3and7
    {
        static void Main()
        {
            int[] nums = new int[] { 35, 14, 15, 70, 175, 333, 245, 623, 375, 231, 35, 700 };

            Console.WriteLine("Lambda : ");
            var NumbersDivisableBy3and7Lambda = nums.Where(x => x % 35 == 0);

            foreach (var item in NumbersDivisableBy3and7Lambda)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("LINQ : ");
            var NumbersDivisableBy3and7LINQ = from num in nums
                                              where num % 35 == 0
                                              select num;

            foreach (var item in NumbersDivisableBy3and7LINQ)
            {
                Console.WriteLine(item);
            }
        }
    }
}
