//Write a program to read a large collection of products (name + price) and 
//efficiently find the first 20 products in the price range [a…b]. Test for 500 000 products and 10 000 price searches.
//Hint: you may use OrderedBag<T> and sub-ranges.


namespace _02.CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class ProductsCollection
    {
        public static Product[] arrayOfProducts;

        public static Random rnd = new Random();

        public const int count = 500000;
        public const int priceCheck = 200;

        public static void Main()
        {
            arrayOfProducts = GetRandomProducts();

            SolveWithSet();

            SolveWithBag();
        }

        private static void SolveWithBag()
        {
            Console.WriteLine("-------");
            Console.WriteLine("bag:");
            Console.WriteLine();
            var sw = new Stopwatch();

            sw.Start();
            var bag = new OrderedBag<Product>();
            Console.WriteLine("Initialize time {0}", sw.Elapsed);

            sw.Restart();
            foreach (var item in arrayOfProducts)
            {
                bag.Add(item);
            }
            Console.WriteLine("Addition time {0}", sw.Elapsed);
            sw.Restart();

            var lowerProduct = new Product("low", 150000);
            var higherProduct = new Product("high", 350000);

            for (int i = 0; i < priceCheck; i++)
            {
                bag.Range(lowerProduct,true, higherProduct,true);
            }
            Console.WriteLine("Price Checking time {0}", sw.Elapsed);
        }

        private static void SolveWithSet()
        {
            Console.WriteLine("-------");
            Console.WriteLine("set:");
            Console.WriteLine();
            var sw = new Stopwatch();

            sw.Start();
            var set = new SortedSet<Product>();
            Console.WriteLine("Initialize time {0}", sw.Elapsed);

            sw.Restart();
            foreach (var item in arrayOfProducts)
            {
                set.Add(item);
            }
            Console.WriteLine("Addition time {0}", sw.Elapsed);
            sw.Restart();

            var lowerProduct = new Product("low", 150000);
            var higherProduct = new Product("high", 350000);

            for (int i = 0; i < priceCheck; i++)
			{
                set.GetViewBetween(lowerProduct, higherProduct);
			}
            Console.WriteLine("Price Checking time {0}", sw.Elapsed);
        }



        private static Product[] GetRandomProducts()
        {
            var productsToReturn = new Product[count];

            for (int i = 0; i < count; i++)
            {
                productsToReturn[i] = new Product(new string((char)rnd.Next(65, 91), rnd.Next(3, 7)), rnd.Next(1, count));
            }

            return productsToReturn;
        }
    }

    public class Product : IComparable<Product>
    {

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
