namespace Company.SampleDataGenerator.SampleDataGenerators
{
    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;

    public abstract class SampleDataGenerator : ISampleDataGenerator
    {
        private CompanyEntities database;
        private IRandomDataGenerator random;
        private ILogger logger;

        public SampleDataGenerator(CompanyEntities companyEntitiesDbContext, IRandomDataGenerator randomDataGenerator, ILogger logger)
        {
            this.database = companyEntitiesDbContext;
            this.random = randomDataGenerator;
            this.logger = logger;
        }

        protected CompanyEntities Database
        {
            get { return this.database; }
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected ILogger Logger
        {
            get { return this.logger; }
        }

        public abstract void Generate(int countToGenerate);
    }
}
