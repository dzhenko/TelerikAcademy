namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class FinancialResultReport
    {
        private IEnumerable<FinancialResultReportEntry> entries;

        public IEnumerable<FinancialResultReportEntry> Report
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
