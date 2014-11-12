namespace BattleNetShop.Client.Console
{
    using BattleNetShop.Logic;

    public class ConsoleClient
    {
        public static void Main()
        {
            // Problem #0
            new DataSeeder().Seed();
            
            // Problem #1
            new ExcelReportsLoader().Load();
            
            // Problem #2
            new PdfReportsGenerator().Generate();
            
            // Problem #3
            new XmlReportsHandler().Generate();
            
            // Problem #4 1
            new JsonReportsGenerator().Generate();
            
            // Problem #4 2
            new MySqlReportsSaver().Save();
            
            // Problem #5
            new XmlReportsHandler().Save();
            
            // Problem #6
            new ExcelXlsxReportGenerator().Generate();
        }
    }
}
