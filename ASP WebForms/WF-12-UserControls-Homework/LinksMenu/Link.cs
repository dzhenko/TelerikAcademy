using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinksMenu
{
    public class Link
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public static IEnumerable<Link> GetLinks()
        {
            return new List<Link>()
            {
                new Link() {Title="Email", Url="http://gmail.com"},
                new Link() {Title="Fun", Url="http://fun.com"},
                new Link() {Title="Facebook", Url="http://facebook.com"},
                new Link() {Title="News", Url="http://news.com"},
                new Link() {Title="Search", Url="http://google.com"},
            };
        }
    }
}