using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}