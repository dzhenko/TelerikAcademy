﻿namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class CategorySalesReportEntry
    {
        public string Category { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmountSold { get; set; }
    }
}
