namespace BattleNetShop.ReportsModel
{
    using System;

    public class FinancialResultReportEntry
    {
        public string VendorName { get; set; }

        public decimal Incomes { get; set; }

        public decimal Expenses { get; set; }

        public decimal Taxes { get; set; }

        public decimal FinancialBalance { get; set; }
    }
}
