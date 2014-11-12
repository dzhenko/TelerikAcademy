namespace BattleNetShop.ReportsModel
{
    using System;
    using System.Collections.Generic;

    public class LocationReport
    {
        public string LocationName { get; set; }

        public IEnumerable<LocationReportEntry> Entries { get; set; }
    }
}
