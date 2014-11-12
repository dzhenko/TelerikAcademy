namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class CategorySalesReport
    {
        private IEnumerable<CategorySalesReportEntry> entries;

        public IEnumerable<CategorySalesReportEntry> Report
        {
            get
            {
                return this.entries;
            }

            set
            {
                this.entries = value;
            }
        }
    }
}
