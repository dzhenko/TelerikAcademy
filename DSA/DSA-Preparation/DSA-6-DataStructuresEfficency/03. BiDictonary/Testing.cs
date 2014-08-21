//Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} 
//and fast search by key1, key2 or by both key1 and key2. Note: multiple values can be stored for given key.

namespace _03.BiDictionary
{
    using System;

    public class Testing
    {
        public static void Main()
        {
            var multi = new BiDictionary<int, string, string>();

            multi.Add(1, "one", "firstElement");

            multi.Add(1, "two", "mixed");

            multi.Add(2, "two", "secondElement");

            Console.WriteLine("first key :");
            var result1 = multi.FindByFirstKey(1);
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("second key :");
            var result2 = multi.FindBySecondKey("two");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("both keys :");
            var result3 = multi.FindByBothKeys(1,"two");
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
