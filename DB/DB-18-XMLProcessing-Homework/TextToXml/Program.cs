using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = string.Empty;
            var address = string.Empty;
            var phone = string.Empty;

            using (var reader = new StreamReader(@"..\..\person.txt"))
            {
                name = reader.ReadLine();
                address = reader.ReadLine();
                phone = reader.ReadLine();
            }

            XElement booksXml = new XElement("Persons",
                new XElement("Person",
                    new XElement("Name", name),
                    new XElement("Address", address),
                    new XElement("Phone", phone)));

            booksXml.Save(@"..\..\person.xml");
        }
    }
}
