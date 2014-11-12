namespace Company.SampleDataGenerator
{
    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;
    using Company.SampleDataGenerator.SampleDataGenerators;

    public class EntryPoint
    {
        public static void Main()
        {
            var database = new CompanyEntities();
            var random = RandomDataGenerator.Instance;
            var logger = new ConsoleLogger();

            database.Configuration.AutoDetectChangesEnabled = false;

            new DepartmentsSampleDataGenerator(database, random, logger).Generate(100);
            new EmployeesSampleDataGenerator(database, random, logger).Generate(5000);
            new ProjectsSampleDataGenerator(database, random, logger).Generate(1000);
            new ReportsSampleDataGenerator(database, random, logger).Generate(250000);

            database.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
