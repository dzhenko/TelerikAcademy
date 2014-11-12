using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogToAlbumX
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

            var albumTitles =
                from album in xmlDoc.Descendants("album")
                select new
                {
                    Name = album.Element("name").Value,
                    Artist = album.Element("artist").Value
                };

            var xElement = new XElement("albums");

            foreach (var albumTitle in albumTitles)
            {
                xElement.Add(new XElement("album", 
                                new XElement("name", albumTitle.Name), 
                                new XElement("artist", albumTitle.Artist)));
            }

            xElement.Save(@"../../../albumX.xml");
        }
    }
}
