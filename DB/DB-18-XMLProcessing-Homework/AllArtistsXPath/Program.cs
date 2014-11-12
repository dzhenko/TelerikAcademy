using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AllArtistsXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            string xPathQuery = "/albums/album";

            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode albumNode in albumsList)
            {
                string albumArtist = albumNode.SelectSingleNode("artist").InnerText;
                Console.WriteLine(albumArtist);
            }
        }
    }
}
