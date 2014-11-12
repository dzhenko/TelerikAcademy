using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAnalyzerClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var client = new ServiceReferenceStringAnalizing.StringAnalyzerClient();

            Console.WriteLine(client.CountSecondStringOccurancesInFirstString("helllo there you hello man hello!", "hello"));

            // Always close the client.
            client.Close();
        }
    }
}
