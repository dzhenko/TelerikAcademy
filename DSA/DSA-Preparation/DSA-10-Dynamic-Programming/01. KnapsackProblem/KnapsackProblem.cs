
namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackProblem
    {
        public const int capacity = 10;

        public static Product[] allProducts;

        public static int[,] valueTable; 

        public static int[,] keepTable;
        
        public static void Main()
        {
            //using products from the task description
            allProducts = GetProductsArray();

            //use your own products
            //GetProductsFromConsole();

            //SolveWithRecursion();

            //valueTable with rows = allProducts + 1(for 0 products)
            //                cows = capacity (+ 1 for faster indexing - from 1 to 10)
            valueTable = new int[allProducts.Length + 1, capacity + 1];
            
            //first row is 0s - the answer if we have 0 items is 0 for all bag capacities!
            for (int prod = 1; prod < valueTable.GetLength(0); prod++)
            {
                for (int cap = 1; cap < valueTable.GetLength(1); cap++)
                {
                    int upperValue = valueTable[prod - 1, cap];
                    int currentValue = GetValueForCurrentCapacity(prod, cap);
                    valueTable[prod, cap] = Math.Max(upperValue, currentValue);
                }
            }

            var usedProducts = GetUsedProductsArray();

            PrintResults(usedProducts);
        }

        private static void PrintResults(IEnumerable<Product> usedProducts)
        {
            var usedSpace = 0;
            var totalCost = 0;

            foreach (var item in usedProducts)
            {
                Console.WriteLine(item);
                usedSpace += item.Weight;
                totalCost += item.Cost;
            }

            Console.WriteLine("Total weight: {0}",usedSpace);
            Console.WriteLine("Total cost: {0}", totalCost);
        }

        private static List<Product> GetUsedProductsArray()
        {
            List<Product> usedProducts = new List<Product>();

            int leftWeight = capacity;
            int ItemIndex = allProducts.Length;

            //the 1st row is only 0
            while (ItemIndex > 0)
            {
                //if true we actually used this item              //compensating 0based array
                if (valueTable[ItemIndex,leftWeight] != valueTable[ItemIndex - 1,leftWeight])
                {
                    usedProducts.Add(allProducts[ItemIndex - 1]);
                    //we move on a column with the remaining weight
                    leftWeight -= allProducts[ItemIndex - 1].Weight;
                }

                ItemIndex--;
            }

            return usedProducts;
        }

        private static int GetValueForCurrentCapacity(int prod, int cap)
        {
            //our 1st product is actually the 0th in the array
            int productIndex = prod - 1;

            //the product fits
            if (allProducts[productIndex].Weight <= cap)
            {
                return allProducts[productIndex].Cost + valueTable[prod - 1, cap - allProducts[productIndex].Weight];
                                                                  //the previous row in the value table:
                                                                  //not to be confused with the 0 basing of the product array

                                                                             //can we fill the rest of the space with an item ?
                                                                             //already solved this - look up in the table
            }

            return 0;
        }

        #region Recursion Solution
        private static void SolveWithRecursion()
        {
            HashSet<Product> usedProducts = new HashSet<Product>();
            int usedCost = 0;

            HashSet<Product> optimalSolution = new HashSet<Product>();
            int bestCost = 0;

            Recursion(0, usedProducts, optimalSolution, ref usedCost, ref bestCost);

            Console.WriteLine("Optimal solution with Recursion:");
            Console.WriteLine(string.Join(", ", optimalSolution));

            var totalWeight = optimalSolution.Select(x => x.Weight).Aggregate((y,z) => y + z);

            Console.WriteLine("Total weight: {0} Total cost: {1}",totalWeight,bestCost);
        }

        private static void Recursion(int capacityUsed, HashSet<Product> usedProducts, HashSet<Product> optimalSolution, 
            ref int usedCost, ref int bestCost)
        {
            if (capacityUsed > capacity)
            {
                return;
            }

            if (usedCost > bestCost)
            {
                bestCost = usedCost;
                optimalSolution.Clear();

                foreach (var p in usedProducts)
                {
                    optimalSolution.Add(p);
                }
            }

            foreach (var product in allProducts)
            {
                if (capacityUsed + product.Weight <= capacity && !usedProducts.Contains(product))
                {
                    usedProducts.Add(product);
                    usedCost += product.Cost;

                    Recursion(capacityUsed + product.Weight, usedProducts, optimalSolution, ref usedCost, ref bestCost);

                    usedProducts.Remove(product);
                    usedCost -= product.Cost;
                }
            }
        }
        #endregion

        #region Read/Generate Data
        private static Product[] GetProductsArray()
        {
            return new Product[]
            {
                new Product("beer",3,2),
                new Product("vodka",8,12),
                new Product("cheese",4,5),
                new Product("nuts",1,4),
                new Product("ham",2,3),
                new Product("whiskey",8,13),
            };
        }

        private static Product[] GetProductsFromConsole()
        {
            var productsToReturn = new List<Product>();

            Console.WriteLine("Write each product in the format N/W/C, where N is name, W is weight, C is cost - example : nuts/1/20");
            Console.WriteLine("Press return to stop");

            string currLine = Console.ReadLine();

            while (currLine != null)
            {
                var tokens = currLine.Split('/');

                productsToReturn.Add(new Product(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));

                currLine = Console.ReadLine();
            }

            return productsToReturn.ToArray();
        }
        #endregion
    }

    public class Product
    {
        public Product(string name,int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Cost { get; private set; }
        
        public override string ToString()
        {
            return string.Format("{0} - weight {1}, cost {2}", this.Name, this.Weight, this.Cost);
        }
    }
}
