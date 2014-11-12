namespace Company.SampleDataGenerator.SampleDataGenerators
{
    using System.Linq;
    using System.Collections.Generic;

    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;

    public class DepartmentsSampleDataGenerator : SampleDataGenerator, ISampleDataGenerator
    {
        public DepartmentsSampleDataGenerator(CompanyEntities companyEntitiesDbContext, IRandomDataGenerator randomDataGenerator, ILogger logger)
            : base(companyEntitiesDbContext, randomDataGenerator, logger)
        {
        }

        public override void Generate(int countToGenerate)
        {
            this.Logger.Log("Generating Departments\n");

            // getting all the names of the departments that are already in the database
            var usedDepartmentsNames = new HashSet<string>(this.Database.Departments.Select(d => d.Name));

            var generatedSoFar = 0;

            while (generatedSoFar < countToGenerate)
            {
                var nameToUse = this.Random.GetString(10, 50);

                if (usedDepartmentsNames.Contains(nameToUse))
                {
                    continue;
                }

                this.Database.Departments.Add(new Department() 
                {
                    Name = nameToUse
                });

                generatedSoFar++;

                if (generatedSoFar % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }
            }

            this.Database.SaveChanges();

            this.Logger.Log("Done\n");
        }
    }
}
