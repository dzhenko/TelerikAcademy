using System;
namespace TradeCompany
{
    public class Product : IComparable<Product>
    {
        public string Title { get; set; }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return this.Title + " price : " + this.Price;
        }

        public int CompareTo(Product other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}
