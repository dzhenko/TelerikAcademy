namespace BattleNetShop.Model
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductDetails")]
    public class ProductDetails
    {
        private ICollection<Product> products;

        public ProductDetails()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [MaxLength]
        public string Description { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
