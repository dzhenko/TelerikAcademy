namespace SortingHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var sw = new Stopwatch();

            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("SelectionSorter result:");
            sw.Start();
            collection.Sort(new SelectionSorter<int>());
            Console.WriteLine("Time : {0}",sw.ElapsedTicks);
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("Quicksorter result:");
            sw.Restart();
            collection.Sort(new Quicksorter<int>());
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("MergeSorter result:");
            sw.Restart();
            collection.Sort(new MergeSorter<int>());
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Linear search 101:");
            sw.Restart();
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            Console.WriteLine();

            Console.WriteLine("Binary search 101:");
            sw.Restart();
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            Console.WriteLine();

            Console.WriteLine("Shuffle:");
            sw.Restart();
            collection.Shuffle();
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            sw.Restart();
            collection.Shuffle();
            Console.WriteLine("Time : {0}", sw.ElapsedTicks);
            collection.PrintAllItemsOnConsole();
        }
    }
}
