using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweets
{
    public class Tweet
    {
        public string User { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}