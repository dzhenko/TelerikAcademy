namespace GenericListClass
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Testing
    {
        public static void Main()
        {
            GenericList<int> test1 = new GenericList<int>(3);
            GenericList<string> test2 = new GenericList<string>(3);
            GenericList<byte> test3 = new GenericList<byte>(3);
            Console.WriteLine("Testing adding");
            test1.Add(2);
            test1.Add(3);
            Console.WriteLine("Testing indexing");
            Console.WriteLine(test1[0]);
            Console.WriteLine(test1[1]);
            Console.WriteLine(test1[0] + test1[1]);
            Console.WriteLine("Testing clear");
            test1.Clear();
            //Console.WriteLine(test1[0]); // this will produce error
            test1.Add(1);
            Console.WriteLine(test1[0]);
            //Console.WriteLine(test1[1]); // this will produce error
            Console.WriteLine("Testing Remove At");
            test1.Add(2);
            test1.Add(3);

            Console.WriteLine(test1[1]);

            test1.RemoveAt(1);
            test1.Add(7);
            Console.WriteLine(test1[1]);

            Console.WriteLine("testing InsertAt");
            test1.Clear();
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.InsertAt(9, 2);
            Console.WriteLine(test1[1]);
            Console.WriteLine(test1[2]);
            Console.WriteLine(test1[3]);

            Console.WriteLine("testing Find");
            Console.WriteLine(test1.Find(0));
            Console.WriteLine(test1.Find(9));
            Console.WriteLine(test1.Find(4));

            Console.WriteLine("testing To String");
            Console.WriteLine(test1);

            Console.WriteLine("Testing min and max");
            Console.WriteLine(test1.Min());
            Console.WriteLine(test1.Max());

            test2.Add("asd");
            test2.Add("angry");
            test2.Add("angraer");
            Console.WriteLine(test2.Min());
            Console.WriteLine(test2.Max());
        }
    }
}
