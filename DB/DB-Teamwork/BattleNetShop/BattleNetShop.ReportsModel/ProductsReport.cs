namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class ProductsReport
    {
        private IEnumerable<ProductsReportEntry> products;

        public ProductsReport()
        {
            this.products = new List<ProductsReportEntry>();
        }

        public DateTime Date { get; set; }

        public IEnumerable<ProductsReportEntry> Products
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
