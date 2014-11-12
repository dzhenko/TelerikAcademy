using System;
using System.Linq;

namespace Todos.Data.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Changed { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}