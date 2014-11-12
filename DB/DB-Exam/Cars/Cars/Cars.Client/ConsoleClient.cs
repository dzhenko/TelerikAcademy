namespace Cars.Client
{
    using System.Linq;

    using Cars.Data;
    using Cars.Client.Logger;

    public class ConsoleClient
    {
        public static void Main()
        {
            var db = new CarsDbContext();
            var logger = new ConsoleLogger();

            var json = new JsonImporter(db, logger);
            json.ImportDirectory(@"..\..\..\..\Data.Json.Files");

            var xml = new XmlQueriesProcessor(db, logger);
            xml.ProcessQueries(@"..\..\..\..\Queries.xml", @"..\..\..\..\QueriesResults\");
        }
    }
}
