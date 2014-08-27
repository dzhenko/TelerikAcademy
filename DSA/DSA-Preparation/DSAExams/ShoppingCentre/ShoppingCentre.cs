namespace FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingCentre
    {
        public static OrderedMultiDictionary<double, Product> productsByPriceRange = new OrderedMultiDictionary<double, Product>(true);
        public static MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        public static MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        public static MultiDictionary<Tuple<string, string>, Product> productsByNameProducer = new MultiDictionary<Tuple<string, string>, Product>(true);

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
            var price = double.Parse(tokens[1]);
            var producer = tokens[2];
            var productToAdd = new Product(name, price, producer);

            productsByNameProducer[new Tuple<string, string>(name, producer)].Add(productToAdd);
            productsByPriceRange[price].Add(productToAdd);
            productsByName[name].Add(productToAdd);
            productsByProducer[producer].Add(productToAdd);

            answer.AppendLine("Product added");
        }

        public static void DeleteByNameProducer(string name,string producer)
        {
            var tuple = new Tuple<string, string>(name, producer);
            if (!productsByNameProducer.ContainsKey(tuple) || productsByNameProducer[tuple].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToRemove = productsByNameProducer[tuple];
            int counter = productsToRemove.Count;

            foreach (var pr in productsToRemove)
            {
                var price = pr.Price;
                productsByPriceRange[price].Remove(pr);
                productsByName[name].Remove(pr);
                productsByProducer[producer].Remove(pr);
            }

            productsByNameProducer.Remove(tuple);

            answer.AppendLine(string.Format("{0} products deleted", counter));
        }

        public static void DeleteByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer) || productsByProducer[producer].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToRemove = productsByProducer[producer];
            int counter = productsToRemove.Count;

            foreach (var pr in productsToRemove)
            {
                var name = pr.Name;
                var price = pr.Price;
                productsByNameProducer[new Tuple<string, string>(name, producer)].Remove(pr);
                productsByPriceRange[price].Remove(pr);
                productsByName[name].Remove(pr);
            }

            productsByProducer.Remove(producer);

            answer.AppendLine(string.Format("{0} products deleted", counter));
        }

        public static void FindByPriceRange(string command)
        {
            var tokens = command.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var fromPrice = double.Parse(tokens[0]);
            var toPrice = double.Parse(tokens[1]);

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
            var ordered = temp.OrderBy(x => x.Name).ThenBy(x=>x.Producer).ThenBy(x=>x.Price);

            foreach (var item in ordered)
            {
                answer.AppendLine(item.ToString());
            }
        }

        public static void FindByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer) || productsByProducer[producer].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }

            var productsToShow = productsByProducer[producer].OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price);

            foreach (var pr in productsToShow)
            {
                answer.AppendLine(pr.ToString());
            }

        }

        public static void FindByName(string name)
        {
            if (!productsByName.ContainsKey(name) || productsByName[name].Count == 0)
            {
                answer.AppendLine("No products found");
                return;
            }
            var productsToShow = productsByName[name].OrderBy(x => x.Name).ThenBy(x => x.Producer).ThenBy(x => x.Price);
            foreach (var pr in productsToShow)
            {
                answer.AppendLine(pr.ToString());
            }
            
        }
    }

    public class Product : IComparable<Product>
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Producer { get; private set; }

        public Product(string name, double price, string producer)
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

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            if (other == null)
            {
                return false;
            }
            if (this.Name != other.Name)
            {
                return false;
            }
            if (this.Price != other.Price)
            {
                return false;
            }
            if (this.Producer != other.Producer)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Producer.GetHashCode();
        }
    }
}
