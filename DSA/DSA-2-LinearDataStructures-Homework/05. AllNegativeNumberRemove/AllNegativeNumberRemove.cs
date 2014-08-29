//Write a program that removes from given sequence all negative numbers.


namespace _05.AllNegativeNumberRemove
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AllNegativeNumberRemove
    {
        static void Main()
        {
            List<int> sequence = new List<int>() {1,-4,22,-13,-11,2,0,88,-192 };

            sequence.RemoveAll(x => x < 0);

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
