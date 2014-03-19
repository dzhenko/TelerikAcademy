namespace FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static OrderedDictionary<decimal, Bag<Product>> productsByPriceRange = new OrderedDictionary<decimal, Bag<Product>>();
        public static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        public static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();

        public static StringBuilder answer = new StringBuilder();

        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string currLine = Console.ReadLine();

                if (currLine.StartsWith("AddProduct"))
                {
                    AddProduct(currLine.Substring(11));
                }
                else if (currLine.StartsWith("DeleteProducts"))
                {
                    currLine = currLine.Substring(15);
                    if (currLine.Contains(';'))
                    {
                        var tokens = currLine.Split(new char[] { ';',}, StringSplitOptions.RemoveEmptyEntries);
                        DeleteByNameProducer(tokens[0], tokens[1]);
                    }
                    else
                    {
                        DeleteByProducer(currLine);
                    }
                }
                else if (currLine.StartsWith("FindProductsByName"))
                {
                    FindByName(currLine.Substring(19));
                }
                else if (currLine.StartsWith("FindProductsByPriceRange"))
                {
                    FindByPriceRange(currLine.Substring(25));
                }
                else
                {
                    FindByProducer(currLine.Substring(23));
                }
            }

            Console.Write(answer);
        }

        public static void AddProduct(string command)
        {
            var tokens = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var price = decimal.Parse(tokens[1]);
            var producer = tokens[2];
            var productToAdd = new Product(name, price, producer);

            if (!productsByName.ContainsKey(name))
            {
                productsByName.Add(name, new Bag<Product>());
            }

            if (!productsByProducer.ContainsKey(producer))
            {
                productsByProducer.Add(producer, new Bag<Product>());
            }

            if (!productsByPriceRange.ContainsKey(price))
            {
                productsByPriceRange.Add(price, new Bag<Product>());
            }

            productsByPriceRange[price].Add(productToAdd);
            productsByName[name].Add(productToAdd);
            productsByProducer[producer].Add(productToAdd);

            answer.AppendLine("Product added");
        }

        public static void DeleteByNameProducer(string name,string producer)
        {
            if (!productsByName.ContainsKey(name) || !productsByProducer.ContainsKey(producer)
                || productsByName[name].Count == 0 || productsByProducer[producer].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToRemove = productsByName[name].Intersection(productsByProducer[producer]);

            foreach (var pr in productsToRemove)
            {
                var price = pr.Price;
                productsByPriceRange[price].Remove(pr);
                productsByName[name].Remove(pr);
                productsByProducer[producer].Remove(pr);
            }

            answer.AppendLine(string.Format("{0} products deleted",productsToRemove.Count));
        }

        public static void DeleteByProducer(string command)
        {
            if (!productsByProducer.ContainsKey(command) || productsByProducer[command].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToRemove = new Bag<Product>();
            productsToRemove.AddMany(productsByProducer[command]);

            foreach (var pr in productsToRemove)
            {
                var name = pr.Name;
                var price = pr.Price;
                productsByPriceRange[price].Remove(pr);
                productsByName[name].Remove(pr);
                productsByProducer[command].Remove(pr);
            }

            answer.AppendLine(string.Format("{0} products deleted", productsToRemove.Count));
        }

        public static void FindByPriceRange(string command)
        {
            var tokens = command.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var fromPrice = decimal.Parse(tokens[0]);
            var toPrice = decimal.Parse(tokens[1]);

            var productsToShow = productsByPriceRange.Range(fromPrice, true, toPrice, true);

            if (productsToShow.Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            List<Product> temp = new List<Product>();

            foreach (var pr in productsToShow)
            {
                foreach (var p in pr.Value)
                {
                    temp.Add(p);
                }
            }
            var ordered = temp.OrderBy(x => x.Name);

            foreach (var item in ordered)
            {
                answer.AppendLine(item.ToString());
            }
        }

        public static void FindByProducer(string command)
        {
            if (!productsByProducer.ContainsKey(command) || productsByProducer[command].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }

            var productsToShow = productsByProducer[command].OrderBy(x => x.Name);

            foreach (var pr in productsToShow)
            {
                answer.AppendLine(pr.ToString());
            }

        }

        public static void FindByName(string command)
        {
            if (!productsByName.ContainsKey(command) || productsByName[command].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToShow = productsByName[command].OrderBy(x => x.Name);
            foreach (var pr in productsToShow)
            {
                answer.AppendLine(pr.ToString());
            }
            
        }
    }

    public class Product : IComparable<Product>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Producer { get; private set; }

        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public override string ToString()
        {
            return string.Format("{3}{0};{1};{2:0.00}{4}", this.Name, this.Producer,this.Price,"{","}");
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
