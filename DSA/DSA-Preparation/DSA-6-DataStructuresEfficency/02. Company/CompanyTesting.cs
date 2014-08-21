namespace _02.Company
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class CompanyTesting
    {
        public const int itemsCount = 1000000;
        public const int searchesCount = 1000000;

        public static Random rnd = new Random();

        public static void Main()
        {
            SolveWithMultyDict();

            SolveWithBag();
        }

        private static string GetRandomString()
        {
            return new string(((char)rnd.Next(65,91)),rnd.Next(5,12));
        }

        private static void SolveWithMultyDict()
        {
            Console.WriteLine("---Multidict---");
            OrderedMultiDictionary<int, Product> dict = new OrderedMultiDictionary<int, Product>(true);
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < itemsCount; i++)
            {
                var price = rnd.Next(1, itemsCount);
                dict.Add(price, new Product(GetRandomString(), GetRandomString(), GetRandomString(), price));
            }
            Console.WriteLine("Added {0} items in {1} time",itemsCount,sw.Elapsed);

            sw.Restart();
            for (int i = 0; i < searchesCount; i++)
            {
                dict.Range(rnd.Next(0, itemsCount / 2), true, rnd.Next(itemsCount/2,itemsCount), true);
            }
            Console.WriteLine("Found Range {0} items in {1} time", searchesCount, sw.Elapsed);
        }

        private static void SolveWithBag()
        {
            Console.WriteLine("---Bag---");
            OrderedBag<Product> bag = new OrderedBag<Product>();
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < itemsCount; i++)
            {
                var price = rnd.Next(1, itemsCount);
                bag.Add(new Product(GetRandomString(), GetRandomString(), GetRandomString(), price));
            }
            Console.WriteLine("Added {0} items in {1} time", itemsCount, sw.Elapsed);

            sw.Restart();
            var secondWatch = new Stopwatch();
            for (int i = 0; i < searchesCount; i++)
            {
                var lowerProduct = new Product(GetRandomString(), GetRandomString(), GetRandomString(), rnd.Next(1, itemsCount / 2));
                var upperProduct = new Product(GetRandomString(), GetRandomString(), GetRandomString(), rnd.Next(1, itemsCount / 2));

                secondWatch.Start();
                bag.Range(lowerProduct,true,upperProduct,true);
                secondWatch.Stop();
            }
            Console.WriteLine("Found Range {0} items in {1} time", searchesCount, sw.Elapsed);
            Console.WriteLine("Actual time spent getting the Range : {0}",secondWatch.Elapsed);
        }
    }
}
