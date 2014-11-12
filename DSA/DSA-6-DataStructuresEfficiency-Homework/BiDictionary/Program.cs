using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    class Program
    {
        static void Main()
        {
            var bi = new BiDictionary<string, int, string>();

            bi.Add("key1", 1, "value11");
            bi.Add("key1", 2, "value12");
            bi.Add("key1", 3, "value13");
            bi.Add("key2", 1, "value21");
            bi.Add("key2", 2, "value22");
            bi.Add("key2", 3, "value23");

            Console.WriteLine(bi.FindByFirstKey("key1"));

            Console.WriteLine(bi.FindBySecondKey(1));

            Console.WriteLine(bi.FindByBothKeys("key1",3));
        }
    }
}
