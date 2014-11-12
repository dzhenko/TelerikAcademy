namespace BattleNetShop.Model
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        private ICollection<Product> products;
        private ICollection<VendorExpense> vendorExpenses;

        public Vendor()
        {
            this.products = new HashSet<Product>();
            this.vendorExpenses = new HashSet<VendorExpense>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<VendorExpense> VendorExpenses
        {
            get
            {
                return this.vendorExpenses;
            }

            set
            {
                this.vendorExpenses = value;
            }
        }

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
