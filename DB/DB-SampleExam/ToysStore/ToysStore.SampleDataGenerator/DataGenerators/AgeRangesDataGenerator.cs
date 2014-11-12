namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.RandomDataGenerators;

    public class AgeRangesDataGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangesDataGenerator(IToysStoreEntities toysStoreEntities, IRandomDataGenerator randomDataGenerator)
            : base(toysStoreEntities, randomDataGenerator)
        {
        }

        public override void Generate(int count)
        {
            var counter = 0;
            for (int i = 0; i < count / 5; i++)
            {
                for (int j = i + 1; j <= i + 5; j++)
                {
                    var ageRange = new AgeRanx()
                    {
                        AgeFrom = i,
                        AgeTo = j
                    };

                    this.Db.AgeRanges.Add(ageRange);

                    counter++;

                    if (counter % 100 == 0)
                    {
                        this.Db.SaveChanges();
                    }

                    if (counter == count)
                    {
                        return;
                    }
                }
            }
        }
    }
}
