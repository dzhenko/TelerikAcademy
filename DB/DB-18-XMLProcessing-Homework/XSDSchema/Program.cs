using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XSDSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = new XmlSchemaSet();
            schema.Add("", @"../../catalog.xsd");

            XDocument catalogDoc = XDocument.Load(@"../../../catalog.xml");
            XDocument albumDoc = XDocument.Load(@"../../../album.xml");

            string result = string.Empty;

            Console.WriteLine("Validating catalog.xml ...");

            catalogDoc.Validate(schema, (o, e) => 
            {
                result = e.Message;
            });

            if (result == string.Empty)
            {
                Console.WriteLine("catalog.xml is a valid xml");
            }
            else
            {
                Console.WriteLine("catalog.xml is not a valid xml");
                Console.WriteLine(result);
            }

            Console.WriteLine();

            Console.WriteLine("Validating album.xml ...");

            albumDoc.Validate(schema, (o, e) =>
            {
                result = e.Message;
            });

            if (result == string.Empty)
            {
                Console.WriteLine("album.xml is a valid xml");
            }
            else
            {
                Console.WriteLine("album.xml is not a valid xml");
                Console.WriteLine(result);
            }
        }
    }
}
