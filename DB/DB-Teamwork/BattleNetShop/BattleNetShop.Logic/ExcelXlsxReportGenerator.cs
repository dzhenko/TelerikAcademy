namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.MySql;
    using BattleNetShop.Data.Excel.Xlsx;
    using BattleNetShop.Data.SqLiteDb;
    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public class ExcelXlsxReportGenerator
    {
        private readonly Lazy<BattleNetShopMySqlData> mySqlData = new Lazy<BattleNetShopMySqlData>();
        private readonly Lazy<BattleNetShopSqLiteData> sqliteData = new Lazy<BattleNetShopSqLiteData>();
        private readonly Lazy<MsSqlReportsFetcher> msSqlFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly Lazy<ExcelXlsxHandler> xlsxHandler = new Lazy<ExcelXlsxHandler>();

        public void Generate()
        {
            Console.WriteLine("Generating Excel reports...");

            this.GenerateVendorsFinancialResultReport();

            this.GenerateSalesPerCategoryReport();
        }

        public void GenerateVendorsFinancialResultReport()
        {
            var random = new Random();
            var salesReport = this.mySqlData.Value.LoadReports();
            var productsTaxes = this.sqliteData.Value.GetAllProducTaxes().ToList();
            var vendorsExpenses = salesReport.Select(sr => new VendorExpense()
            {
                VendorName = sr.VendorName,
                Ammount = 10 * random.Next(10, 30)
            });
            var salesJoinedWithTaxesGroupedByVendor = salesReport
                    .Join(productsTaxes,
                        (s => s.ProductName),
                        (pt => pt.ProductName),
                        (s, pt) => new { VendorName = s.VendorName, TotalIncome = s.TotalIncomes, TotalIncomeWithTax = s.TotalIncomes * (pt.Amount / 100) })
                    .GroupBy(s => s.VendorName)
                    .Select(sg => new { VendorName = sg.Key, TotalIncomes = sg.Sum(s => s.TotalIncome), TotalIncomeWithTax = sg.Sum(s => s.TotalIncomeWithTax) })
                    .ToList();
            var vendorFinancialInfoJoinedWithExpenses = salesJoinedWithTaxesGroupedByVendor
                    .Join(vendorsExpenses,
                        (f => f.VendorName),
                        (e => e.VendorName),
                        (f, e) => new { VendorName = f.VendorName, TotalIncomes = f.TotalIncomes, TotalIncomeWithTax = f.TotalIncomeWithTax, Expenses = e.Ammount })
                        .GroupBy(fg => fg.VendorName)
                    .Select(fg => new { VendorName = fg.Key, TotalIncomes = fg.Sum(f => f.TotalIncomes), TotalIncomeWithTax = fg.Sum(f => f.TotalIncomeWithTax), Expenses = fg.Sum(f => f.Expenses) })
            .ToList();
            var reportEntries = new LinkedList<FinancialResultReportEntry>();
            foreach (var row in vendorFinancialInfoJoinedWithExpenses.ToList())
            {
                var reportRecord = new FinancialResultReportEntry();
                reportRecord.VendorName = row.VendorName;
                reportRecord.Incomes = row.TotalIncomes;
                reportRecord.Expenses = (decimal)row.Expenses;
                reportRecord.Taxes = (decimal)row.TotalIncomeWithTax;
                reportRecord.FinancialBalance = (decimal)(reportRecord.Incomes - reportRecord.Taxes - reportRecord.Expenses);
                reportEntries.AddLast(reportRecord);
            }
            var reportData = new FinancialResultReport();
            reportData.Report = reportEntries;
            this.xlsxHandler.Value.GenerateVendorsFinancialResultFile(reportData, "FinancialBalanceResults.xlsx");
        }

        public void GenerateSalesPerCategoryReport()
        {
            var salesPerCategoryReport = this.msSqlFetcher.Value.GetSalesByCategory();
            this.xlsxHandler.Value.GenerateSalesPerCategoryResultFile(salesPerCategoryReport, "SalesPerCategory.xlsx");
        }
    }
}
