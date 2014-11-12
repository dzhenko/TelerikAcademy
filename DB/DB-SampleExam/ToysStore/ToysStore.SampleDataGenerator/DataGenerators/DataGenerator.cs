namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    public abstract class DataGenerator : IDataGenerator
    {
        private IToysStoreEntities db;
        private IRandomDataGenerator random;

        public DataGenerator(IToysStoreEntities toysStoreEntities, IRandomDataGenerator randomDataGenerator)
        {
            this.db = toysStoreEntities;
            this.random = randomDataGenerator;
        }

        protected IToysStoreEntities Db
        {
            get { return this.db; }
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        public abstract void Generate(int count);
    }
}
