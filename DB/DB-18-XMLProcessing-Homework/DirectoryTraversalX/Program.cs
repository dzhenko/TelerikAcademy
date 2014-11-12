using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DirectoryTraversalX
{
    class Program
    {
        static void Main()
        {
            Traverse(@"C:\Windows\Help", @"..\..\..\directoryX.xml");
        }

        static void Traverse(string directoryPath, string xmlResultPath)
        {
            var xElement = new XElement("root-directory", new XAttribute("path", directoryPath));

            xElement.Add(GetDirectoryElement(directoryPath));

            xElement.Save(xmlResultPath);
        }

        private static XElement GetFileElement(string file)
        {
            return new XElement("file", new XAttribute("name", file), new XAttribute("size", new FileInfo(file).Length.ToString()));
        }

        private static XElement GetDirectoryElement(string dir)
        {
            var dirElement = new XElement("dir", new XAttribute("name", dir));
            foreach (var subDir in Directory.GetDirectories(dir))
            {
                dirElement.Add(GetDirectoryElement(subDir));
            }
            foreach (var subFile in Directory.GetFiles(dir))
            {
                dirElement.Add(GetFileElement(subFile));
            }

            return dirElement;
        }
    }
}
