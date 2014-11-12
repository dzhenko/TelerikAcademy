namespace TradeCompany
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            var allItems = new OrderedMultiDictionary<decimal, Product>(true);

            for (int i = 0; i < 100000; i++)
            {
                allItems.Add(i, new Product() { Price = i, Barcode = i.ToString(), Title = i.ToString(), Vendor = i.ToString() });
            }

            var rangeItems = allItems.Range(5000, true, 6000, true);

            Console.WriteLine(string.Join(Environment.NewLine, rangeItems.Select(i => string.Join(", ", i.Value))));
        }
    }
}
