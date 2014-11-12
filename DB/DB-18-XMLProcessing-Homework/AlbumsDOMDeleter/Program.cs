using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlbumsDOMDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            var nodesToDelete = new List<XmlNode>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var priceNode = node["price"];
                if (priceNode != null)
                {
                    var price = decimal.Parse(priceNode.InnerText);
                    if (price > 20)
                    {
                        Console.WriteLine("Removing album with price {0} ... ", price);
                        nodesToDelete.Add(node);
                    }
                }
            }

            foreach (var node in nodesToDelete)
            {
                rootNode.RemoveChild(node);
            }

            doc.Save("../../../deleted.xml");
        }
    }
}
