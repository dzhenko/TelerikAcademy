namespace ToysStore.SampleDataGenerator
{
    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.DataGenerators;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    public class DataGenerator
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToysStoreEntities();

            var ageRanges = new AgeRangesDataGenerator(db, random);

            ageRanges.Generate(100);

            db.SaveChanges();
        }
    }
}
