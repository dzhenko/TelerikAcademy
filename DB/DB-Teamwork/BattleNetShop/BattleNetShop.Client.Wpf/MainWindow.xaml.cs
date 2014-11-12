namespace BattleNetShop.Client.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using BattleNetShop.Logic;
    using System.Threading;
    using System.Diagnostics;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Lazy<ExcelReportsLoader> excelLoader = new Lazy<ExcelReportsLoader>();
        private Lazy<MySqlReportsSaver> mySqlReportSaver = new Lazy<MySqlReportsSaver>();
        private Lazy<PdfReportsGenerator> pdfReportsGenerator = new Lazy<PdfReportsGenerator>();
        private Lazy<JsonReportsGenerator> jsonReportsGenerator = new Lazy<JsonReportsGenerator>();
        private Lazy<XmlReportsHandler> XmlReportsHandler = new Lazy<XmlReportsHandler>();
        private Lazy<ExcelXlsxReportGenerator> excelReportsGenerator = new Lazy<ExcelXlsxReportGenerator>();
        private Lazy<DataSeeder> dataSeeder = new Lazy<DataSeeder>();

        private string itemName = string.Empty;
        private string locationName = string.Empty;
        private DateTime? purchaseDate = DateTime.Now;

        private PdfReportType pdfOption = PdfReportType.AllReports;

        private IEnumerable<string> allItemNames;
        private IEnumerable<string> allLocationNames;
        private DateTime maxPurchaseDate;

        private string excelOption = "all";

        public MainWindow()
        {
            InitializeComponent();

            InitializeMenues();
        }

        private void InitializeMenues()
        {
            var clientInfo = new ClientInformation();

            if (!clientInfo.AnyData())
            {
                this.dataSeeder.Value.Seed();

                this.excelLoader.Value.Load();
            }

            this.allItemNames = clientInfo.GetAllProductNames();
            this.allLocationNames = clientInfo.GetAllLocationNames();
            this.maxPurchaseDate = clientInfo.GetLastPurchaseDate();

            PdfDate.SelectedDate = new DateTime(2014, 1, 1);

            PdfDate.DisplayDateEnd = this.maxPurchaseDate;

            PdfDate.SelectedDateChanged += PdfDate_SelectedDateChanged;

            PdfDate.Visibility = System.Windows.Visibility.Hidden;
            PdfItemNameP.Visibility = System.Windows.Visibility.Hidden;
            PdfRealmNameP.Visibility = System.Windows.Visibility.Hidden;

            foreach (PdfReportType reportType in (PdfReportType[])Enum.GetValues(typeof(PdfReportType)))
            {
                var choice = new MenuItem()
                {
                    Header = reportType.ToString()
                };

                choice.Click += choice_Click;

                PdfChoice.Items.Add(choice);
            }

            foreach (var product in allItemNames)
            {
                var item = new MenuItem()
                {
                    Header = product
                };

                item.Click += PdfItemName_Click;

                PdfItemName.Items.Add(item);
            }

            foreach (var product in allLocationNames)
            {
                var item = new MenuItem()
                {
                    Header = product
                };

                item.Click += PdfRealmName_Click;

                PdfRealmName.Items.Add(item);
            }

            var excelOptionAll = new MenuItem();
            excelOptionAll.Header = "All reports";
            excelOptionAll.Click += (e, r) => { this.excelOption = "all"; ExcelChoice.Header = "All reports"; };
            ExcelChoice.Items.Add(excelOptionAll);

            var excelOptionVendors = new MenuItem();
            excelOptionVendors.Header = "Vendors report";
            excelOptionVendors.Click += (e, r) => { this.excelOption = "vendors"; ExcelChoice.Header = "Vendors report"; };
            ExcelChoice.Items.Add(excelOptionVendors);

            var excelOptionSales = new MenuItem();
            excelOptionSales.Header = "Sales report";
            excelOptionSales.Click += (e, r) => { this.excelOption = "sales"; ExcelChoice.Header = "Sales report"; };
            ExcelChoice.Items.Add(excelOptionSales);
        }

        void choice_Click(object sender, RoutedEventArgs e)
        {
            var choice = ((MenuItem)sender).Header.ToString();

            PdfChoice.Header = choice;

            if (choice == "AllReports" || choice == "AllProducts")
            {
                PdfDate.Visibility = System.Windows.Visibility.Hidden;
                PdfItemNameP.Visibility = System.Windows.Visibility.Hidden;
                PdfRealmNameP.Visibility = System.Windows.Visibility.Hidden;

                this.pdfOption = choice == "AllReports" ? PdfReportType.AllReports : PdfReportType.AllProducts;
            }
            else if (choice == "ForDate")
            {
                PdfDate.Visibility = System.Windows.Visibility.Visible;
                PdfItemNameP.Visibility = System.Windows.Visibility.Hidden;
                PdfRealmNameP.Visibility = System.Windows.Visibility.Hidden;
                this.pdfOption = PdfReportType.ForDate;

            }
            else if (choice == "ForLocation")
            {
                PdfDate.Visibility = System.Windows.Visibility.Hidden;
                PdfItemNameP.Visibility = System.Windows.Visibility.Hidden;
                PdfRealmNameP.Visibility = System.Windows.Visibility.Visible;
                this.pdfOption = PdfReportType.ForLocation;
            }
            else if (choice == "ForLocationAtDate")
            {
                PdfDate.Visibility = System.Windows.Visibility.Visible;
                PdfItemNameP.Visibility = System.Windows.Visibility.Hidden;
                PdfRealmNameP.Visibility = System.Windows.Visibility.Visible;
                this.pdfOption = PdfReportType.ForLocationAtDate;
            }
            else if (choice == "ForItem")
            {
                PdfDate.Visibility = System.Windows.Visibility.Hidden;
                PdfItemNameP.Visibility = System.Windows.Visibility.Visible;
                PdfRealmNameP.Visibility = System.Windows.Visibility.Hidden;
                this.pdfOption = PdfReportType.ForItem;
            }
        }

        void PdfDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.purchaseDate = ((DatePicker)sender).SelectedDate;
        }

        private void PdfItemName_Click(object sender, RoutedEventArgs e)
        {
            this.itemName = ((MenuItem)sender).Header.ToString();
            PdfItemName.Header = this.itemName;
        }

        private void PdfRealmName_Click(object sender, RoutedEventArgs e)
        {
            this.locationName = ((MenuItem)sender).Header.ToString();
            PdfRealmName.Header = this.locationName;
        }

        private void Pdf_Generate(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() => 
            {
                switch (this.pdfOption)
                {
                    case PdfReportType.AllReports: this.pdfReportsGenerator.Value.Generate();
                        break;
                    case PdfReportType.AllProducts: this.pdfReportsGenerator.Value.GenerateAllProductsInformation();
                        break;
                    case PdfReportType.ForDate:
                        if (this.purchaseDate > this.maxPurchaseDate)
                        {
                            this.purchaseDate = this.maxPurchaseDate;
                        }
                        else if (this.purchaseDate < new DateTime(2014, 1, 1))
                        {
                            this.purchaseDate = new DateTime(2014, 1, 1);
                        }
                        this.pdfReportsGenerator.Value.GenerateAllProductsReportForDate((DateTime)this.purchaseDate);
                        break;
                    case PdfReportType.ForLocation: this.pdfReportsGenerator.Value.GenerateTotalLocationReport(this.locationName);
                        break;
                    case PdfReportType.ForLocationAtDate:
                        if (this.purchaseDate > this.maxPurchaseDate)
                        {
                            this.purchaseDate = this.maxPurchaseDate;
                        }
                        else if (this.purchaseDate < new DateTime(2014, 1, 1))
                        {
                            this.purchaseDate = new DateTime(2014, 1, 1);
                        }
                        this.pdfReportsGenerator.Value.GenerateLocationReportForDate(this.locationName, (DateTime)this.purchaseDate);
                        break;
                    case PdfReportType.ForItem: this.pdfReportsGenerator.Value.GenerateProductInfoForLocations(this.itemName);
                        break;
                    default:
                        break;
                }

                MessageBox.Show("PDF Report created");
            })).Start();
        }

        private void Json_Generate(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.jsonReportsGenerator.Value.Generate();

                MessageBox.Show("JSON Report created");
            })).Start();
        }

        private void Xml_Generate(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.XmlReportsHandler.Value.Generate();

                MessageBox.Show("XML Report created");
            })).Start();
        }

        private void Excel_Generate(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                if (this.excelOption == "all")
                {
                    this.excelReportsGenerator.Value.Generate();
                }
                else if (this.excelOption == "vendors")
                {
                    this.excelReportsGenerator.Value.GenerateVendorsFinancialResultReport();
                }
                else if (this.excelOption == "sales")
                {
                    this.excelReportsGenerator.Value.GenerateSalesPerCategoryReport();
                }

                MessageBox.Show("Excel Report created");
            })).Start();
        }

        private void Seed_Data(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.dataSeeder.Value.Seed();

                MessageBox.Show("Data successfully seeded.");
            })).Start();
        }

        private void Open_Folder(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\Users\dzhenko\Documents\Visual Studio 2013\Projects\BattleNetShop\Reports\");
        }

        private void SQL_Load(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.excelLoader.Value.Load();

                MessageBox.Show("Data successfully loaded to SQL Server.");
            })).Start();
        }

        private void XML_Load(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.XmlReportsHandler.Value.Save();

                MessageBox.Show("Data successfully loaded from XML.");
            })).Start();
        }

        private void MySql_Load(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                this.mySqlReportSaver.Value.Save();

                MessageBox.Show("Data successfully saved to MySql.");
            })).Start();
        }
    }
}
