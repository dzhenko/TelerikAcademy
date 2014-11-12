namespace Company.SampleDataGenerator.SampleDataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;

    public class ProjectsSampleDataGenerator : SampleDataGenerator, ISampleDataGenerator
    {
        public ProjectsSampleDataGenerator(CompanyEntities companyEntitiesDbContext, IRandomDataGenerator randomDataGenerator, ILogger logger)
            : base(companyEntitiesDbContext, randomDataGenerator, logger)
        {
        }

        public override void Generate(int countToGenerate)
        {
            this.Logger.Log("Generating Projects\n");

            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < countToGenerate; i++)
            {
                var project = new Project()
                {
                    Name = this.Random.GetString(5, 50)
                };

                // average between 2 and 20 is 11.
                // we require an average of 5 - so we make 1 / 4 with 2 to 20 and 3 / 4 with 4
                // that gives us 1 / 4 * 11 + 3 / 4 * 4 = around 5
                // test is bellow
                var employeesOnProjectCount = 4;
                if (i % 4 == 0)
                {
                    employeesOnProjectCount = this.Random.GetInt(2, 20);
                }

                var employeeIdsToUse = new HashSet<int>();
                while (employeeIdsToUse.Count < employeesOnProjectCount)
                {
                    employeeIdsToUse.Add(employeeIds[this.Random.GetInt(0, employeeIds.Count - 1)]);
                }

                foreach (var employeeId in employeeIdsToUse)
                {
                    var startDate = new DateTime(this.Random.GetInt(2013,2015), this.Random.GetInt(1,12), this.Random.GetInt(1,25));
                    project.EmployeesProjects.Add(new EmployeesProject() 
                    {
                        EmployeeId = employeeId,
                        StartingDate = startDate,
                        EndingDate = startDate.AddMonths(this.Random.GetInt(6,36))
                    });
                }

                this.Database.Projects.Add(project);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }
            }

            this.Database.SaveChanges();

            this.Logger.Log("Done\n");
        }

        //public static void Test(IRandomDataGenerator random)
        //{
        //    long sum = 0;
        //    for (int i = 0; i < 100000 / 4; i++)
        //    {
        //        sum += random.GetInt(2, 20);
        //    }
        //    for (int i = 0; i < 100000 * 3 / 4; i++)
        //    {
        //        sum += 4;
        //    }

        //    System.Console.WriteLine(sum / 100000);
        //}
    }
}
