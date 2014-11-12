using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SongTitlesXDocumentLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");
            var songTitles =
                from song in xmlDoc.Descendants("song")
                select song.Element("title").Value;

            foreach (var songTitle in songTitles)
            {
                Console.WriteLine(songTitle);
            }
        }
    }
}
