namespace TelerikAcademyForum
{
    using System;
    using System.Linq;
    using System.Net;
    using System.IO;

    using Newtonsoft.Json;
    using System.Xml.Linq;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class TelerikAcademyForum
    {
        public static void Main()
        {
            // Task 1 and 2
            var xmlPath = @"../../rss.xml";
            var htmlPath = @"../../index.html";

            GetRssFeed(xmlPath);

            var xml = XDocument.Load(xmlPath);

            // Task 3
            var json = JsonConvert.SerializeXNode(xml);

            // Task 4
            var allTitles = GetAllTitles(json);

            Console.WriteLine(string.Join(Environment.NewLine, allTitles));

            // Task 5
            var pocoObjects = GetPocoObjects(json);

            // Task 6
            var htmlString = BuildHtmlString(pocoObjects);

            using (var writer = new StreamWriter(htmlPath))
            {
                writer.Write(htmlString);
            }
        }

        private static string BuildHtmlString(IEnumerable<Question> pocoObjects)
        {
            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html><html><head></head><body><h1>Telerik Academy Forum</h1><ul>");

            foreach (var obj in pocoObjects)
            {
                sb.Append("<li><a href=\"");
                sb.Append(obj.Link);
                sb.Append("\">");
                sb.Append(obj.Title);
                sb.Append("</a>[");
                sb.Append(obj.Description);
                sb.Append("]</li>");
            }

            sb.Append("</ul></body></html>");

            Console.WriteLine("HTML Created successfully");
            return sb.ToString();
        }

        private static IEnumerable<Question> GetPocoObjects(string json)
        {
            var jObject = JObject.Parse(json);

            var questionList = jObject["rss"]["channel"]["item"]
                .Select(i => JsonConvert.DeserializeObject<Question>(i.ToString()));

            return questionList;
        }

        private static IEnumerable<object> GetAllTitles(string json)
        {
            var jObject = JObject.Parse(json);

            return jObject["rss"]["channel"]["item"].Select(i => i["title"]);
        }

        private static void GetRssFeed(string filePath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://forums.academy.telerik.com/feed/qa.rss", filePath);
            }
        }
    }
}
