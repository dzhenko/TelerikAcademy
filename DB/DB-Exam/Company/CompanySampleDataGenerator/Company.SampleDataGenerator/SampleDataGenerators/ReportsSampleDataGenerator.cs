namespace Company.SampleDataGenerator.SampleDataGenerators
{
    using System;
    using System.Linq;

    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;

    public class ReportsSampleDataGenerator : SampleDataGenerator, ISampleDataGenerator
    {
        public ReportsSampleDataGenerator(CompanyEntities companyEntitiesDbContext, IRandomDataGenerator randomDataGenerator, ILogger logger)
            : base(companyEntitiesDbContext, randomDataGenerator, logger)
        {
        }

        public override void Generate(int countToGenerate)
        {
            this.Logger.Log("Generating Reports\n");

            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < countToGenerate; i++)
            {
                this.Database.Reports.Add(new Report() 
                {
                    EmployeeId = employeeIds[this.Random.GetInt(0, employeeIds.Count - 1)],
                    Time = new DateTime(this.Random.GetInt(2012,2014), this.Random.GetInt(1,12), this.Random.GetInt(1,25))
                });

                if (i % 100 == 0)
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
