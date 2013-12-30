//Write a program that parses an URL address given in the format:
//
//		and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//		[protocol] = "http"
//		[server] = "www.devbg.org"
//		[resource] = "/forum/index.php"


namespace _12.URLParsing
{
    using System;
    using System.Text;

    class URLParsing
    {
        static void Main()
        {
            string source = "http://www.devbg.org/forum/index.php";

            int indexOfProt = source.IndexOf("://");
            string protocol =  source.Substring(0,indexOfProt);
            protocol = "[protocol] = " + "\"" +protocol + "\"";
            
            int indexOfServer = source.IndexOf("/", indexOfProt + 3);
            string server = source.Substring(indexOfProt + 3, indexOfServer - indexOfProt - 3);
            server = "[server] = " + "\"" + server + "\"";

            string resource = source.Substring(indexOfServer );
            resource = "[resource] = " + "\"" + resource + "\"";

            Console.WriteLine(protocol);
            Console.WriteLine(server);
            Console.WriteLine(resource);
        }
    }
}
