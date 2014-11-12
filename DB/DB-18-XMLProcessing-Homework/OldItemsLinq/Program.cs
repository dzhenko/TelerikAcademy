using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OldItemsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");
            var oldAlbums =
                from album in xmlDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) < 2010
                select album.Element("name").Value;


            foreach (var oldAlbum in oldAlbums)
            {
                Console.WriteLine(oldAlbum);
            }
        }
    }
}
