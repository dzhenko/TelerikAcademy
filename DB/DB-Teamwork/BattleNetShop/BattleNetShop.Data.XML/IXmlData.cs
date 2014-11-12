namespace BattleNetShop.Data.Xml
{
    using System.Collections.Generic;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    /// <summary>
    /// Class holding interactions with XML data.
    /// </summary>
    public interface IXmlData
    {
        /// <summary>
        /// Returns all vendor expenses as IEnumberable collection.
        /// </summary>
        /// <returns>All vendor expensess as IEnumberable.</returns>
        IEnumerable<VendorExpense> GetAllVendorExpenses();

        /// <summary>
        /// Saves all location reports as a xml file.
        /// </summary>
        /// <param name="locationReports">The location reports to save.</param>
        void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports);
    }
}
