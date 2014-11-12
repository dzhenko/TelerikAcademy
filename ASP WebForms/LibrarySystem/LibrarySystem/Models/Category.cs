namespace LibrarySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Book> books;

        public Category()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Index("IX_NameUnique", IsUnique=true)]
        [MaxLength(450)] // unless max length is specified, unique key can not be created
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books 
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}