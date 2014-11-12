namespace BattleNetShop.ReportsModel
{
    using System;

    public class ProductsReportEntry
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Vendor { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public decimal Total
        {
            get
            {
                return Math.Round(this.Quantity * this.Price, 2);
            }
        }
    }
}
