namespace BattleNetShop.Data.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using System.Xml;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public class XmlData : IXmlData
    {
        public void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports)
        {
            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement("sales");
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            foreach (LocationReport locationReport in locationReports)
            {
                XmlElement sale = report.CreateElement("location");
                sale.SetAttribute("name", locationReport.LocationName);
                root.AppendChild(sale);
                foreach (LocationReportEntry entry in locationReport.Entries)
                {
                    XmlElement summary = report.CreateElement("summary");
                    summary.SetAttribute("date", entry.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    summary.SetAttribute("total-sum", entry.TotalSum.ToString());
                    sale.AppendChild(summary);
                }
            }

            if (!Directory.Exists(XmlSettings.Default.ReportDestinationFolderLocation))
            {
                Directory.CreateDirectory(XmlSettings.Default.ReportDestinationFolderLocation);
            }

            report.Save(XmlSettings.Default.ReportDestinationFolderLocation + XmlSettings.Default.ReportDestionationFileName);
        }

        public IEnumerable<VendorExpense> GetAllVendorExpenses()
        {
            var allVendorExpenses = new List<VendorExpense>();

            XmlDocument doc = new XmlDocument();
            doc.Load(XmlSettings.Default.InitialXmlFileLocation);

            XmlNodeList vendorNodesList = doc.SelectNodes("/expenses-by-month/vendor");

            foreach (XmlNode vendorNode in vendorNodesList)
            {
                string vendorName = vendorNode.Attributes.GetNamedItem("name").Value;
                if (string.IsNullOrEmpty(vendorName))
                {
                    throw new ArgumentNullException("Vendor name cannot be empty!");
                }
                XmlNodeList vendorExpenses = vendorNode.SelectNodes("expenses");
                foreach (XmlNode expense in vendorExpenses)
                {
                    VendorExpense vendorExpense = new VendorExpense();
                    vendorExpense.VendorName = vendorName;

                    decimal parsedAmmount = 0;
                    if (!decimal.TryParse(expense.InnerText, NumberStyles.Any, CultureInfo.InvariantCulture,
                        out parsedAmmount))
                    {
                        throw new FormatException("Unable to parse expenses ammount in" + XmlSettings.Default.InitialXmlFileLocation + "! Parse string: " + expense.InnerText);
                    }

                    vendorExpense.Ammount = parsedAmmount;

                    DateTime parsedDate = new DateTime();
                    if (!DateTime.TryParseExact(expense.Attributes.GetNamedItem("month").Value, "MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out parsedDate))
                    {
                        throw new FormatException("Unable to parse date from expenses entry in" + XmlSettings.Default.InitialXmlFileLocation + "! Parse string: " + expense.Attributes.GetNamedItem("month").Value);
                    }

                    vendorExpense.Date = parsedDate;
                    allVendorExpenses.Add(vendorExpense);
                }
            }

            return allVendorExpenses;
        }
    }
}
