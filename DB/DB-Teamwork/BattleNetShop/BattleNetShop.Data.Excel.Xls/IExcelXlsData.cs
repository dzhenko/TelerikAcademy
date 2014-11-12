namespace BattleNetShop.Data.Excel.Xls
{
    using System;
    using System.Collections.Generic;

    using BattleNetShop.Model;

    /// <summary>
    /// Interface holding all xls files data manipulation
    /// </summary>
    public interface IExcelXlsData
    {
        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        void ReadAllPurchases(Action<int, int, decimal, string, DateTime> action);

        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="locationsMapping">Dictionary containing information about how to map each name to index location.</param>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        void ReadAllPurchases(IDictionary<string, int> locationsMapping, Action<Purchase> action);

        /// <summary>
        /// Reads every row of every report and performs an action of your choice.
        /// </summary>
        /// <param name="zipFileLocation">The Zip File To Open</param>
        /// <param name="action">Action to perform on the returned ProductId, Quantity, UnitPrice, LocationName and Date.</param>
        void ReadAllPurchases(string zipFileLocation, Action<int, int, decimal, string, DateTime> action);
    }
}
