using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalyzerClient
{
    public class ConsoleClient
    {
        public static void Main()
        {
            var client = new StringAnalyzerServiceRefference.StringAnalyzerClient();

            Console.WriteLine(client.CountSecondStringOccurancesInFirstString("helllo there you hello man hello!", "hello"));

            // Always close the client.
            client.Close();
        }
    }
}
