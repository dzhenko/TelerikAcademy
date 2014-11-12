namespace _04.JHashTable
{
    using System;
    using System.Linq;

    public class Testing
    {
        public static void Main()
        {
            var jHashTable = new JHashTable<int, string>();

            jHashTable.Add(3, "ar");

            jHashTable[2] = "asd";

            var indexCheck = jHashTable[2];

            Console.WriteLine("toString:");
            Console.WriteLine(jHashTable);

            Console.WriteLine("indexer:");
            Console.WriteLine(jHashTable[2]);
            Console.WriteLine(indexCheck);

            Console.WriteLine("keys:");
            var keysChecker = jHashTable.Keys;

            foreach (var key in keysChecker)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("count:");
            Console.WriteLine(jHashTable.Count);
            Console.WriteLine("remove:");
            jHashTable.Remove(4);

            Console.WriteLine(jHashTable[2]);

            jHashTable.Remove(2);

            Console.WriteLine(jHashTable[2]);
            Console.WriteLine("count:");
            Console.WriteLine(jHashTable.Count);

            string res;
            var findChecker = jHashTable.Find(3, out res);
            Console.WriteLine("Find value by key 3:");
            Console.WriteLine(res);
            Console.WriteLine(findChecker);

            Console.WriteLine(jHashTable);
            Console.WriteLine("clear");
            jHashTable.Clear();
            Console.WriteLine(jHashTable);
            Console.WriteLine("----");
            Console.WriteLine("resize");

            for (int i = 0; i < 100; i++)
            {
                jHashTable.Add(i, i.ToString());
            }

            Console.WriteLine(jHashTable);
        }
    }
}
