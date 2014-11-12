namespace BattleNetShop.Model
{
    using System;

    public class ProductTax
    {
        public ProductTax(string productName, float tax)
        {
            this.ProductName = productName;
            this.Tax = tax;
        }

        public string ProductName { get; set; }

        public float Tax { get; set; }
    }
}
