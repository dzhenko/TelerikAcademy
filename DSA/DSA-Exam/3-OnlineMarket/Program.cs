using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _3_OnlineMarket
{
    class Program
    {
        static Dictionary<string, Product> byName = new Dictionary<string, Product>();

        static OrderedDictionary<string, OrderedBag<Product>> byType = new OrderedDictionary<string, OrderedBag<Product>>();

        static OrderedBag<Product> byPrice = new OrderedBag<Product>();

        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != "end")
            {
                var tokens = line.Split();

                if (tokens[0] == "add")
                {
                    Add(tokens[1].Trim(), double.Parse(tokens[2]), tokens[3].Trim());
                }
                else
                {
                    if (tokens[2] == "type")
                    {
                        FilterType(tokens[3].Trim());
                    }
                    else if (tokens.Length == 7)
                    {
                        FilterBoth(double.Parse(tokens[4]), double.Parse(tokens[6]));
                    }
                    else if (tokens[3] == "from")
                    {
                        FilterFrom(double.Parse(tokens[4]));
                    }
                    else if (tokens[3] == "to")
                    {
                        FilterTo(double.Parse(tokens[4]));
                    }
                }

                line = Console.ReadLine();
            }

            Console.Write(sb.ToString());
        }

        static void Add(string name, double price, string type)
        {
            if (byName.ContainsKey(name))
            {
                sb.AppendLine("Error: Product " + name + " already exists");
            }
            else
            {
                sb.AppendLine("Ok: Product " + name + " added successfully");

                var product = new Product(name, type, price);
                byName.Add(name, product);
                byPrice.Add(product);

                if (!byType.ContainsKey(type))
                {
                    byType.Add(type, new OrderedBag<Product>());
                }

                byType[type].Add(product);
            }
        }

        static void FilterType(string type)
        {
            if (!byType.ContainsKey(type))
            {
                sb.AppendLine("Error: Type " + type + " does not exists");
            }
            else
            {
                sb.Append("Ok: ");
                sb.AppendLine(string.Join(", ", byType[type].Take(10)));
            }
        }

        static void FilterFrom(double from)
        {
            sb.Append("Ok: ");
            var testProduct = new Product("asd", "asd", from);

            var products = byPrice.RangeFrom(testProduct, true).Take(10);

            sb.AppendLine(string.Join(", ", products));
        }

        static void FilterTo(double to)
        {
            sb.Append("Ok: ");
            var testProduct = new Product("asd", "asd", to);

            var products = byPrice.RangeTo(testProduct, true).Take(10);

            sb.AppendLine(string.Join(", ", products));
        }

        static void FilterBoth(double from, double to)
        {
            sb.Append("Ok: ");

            var testProduct1 = new Product("asd", "asd", from);
            var testProduct2 = new Product("asdd", "asdd", to);

            var products = byPrice.Range(testProduct1, true, testProduct2, true).Take(10);

            sb.AppendLine(string.Join(", ", products));
        }
    }

    struct Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public Product(string name, string type, double price) : this()
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            if (this.Price == other.Price)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name + "(" + this.Price + ")";
        }
    }
}
