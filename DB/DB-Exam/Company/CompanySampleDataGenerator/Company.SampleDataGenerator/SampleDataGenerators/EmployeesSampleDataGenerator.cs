﻿namespace Company.SampleDataGenerator.SampleDataGenerators
{
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.SampleDataGenerator.Loggers;
    using Company.SampleDataGenerator.RandomDataGenerators;

    class EmployeesSampleDataGenerator : SampleDataGenerator, ISampleDataGenerator
    {
        public EmployeesSampleDataGenerator(CompanyEntities companyEntitiesDbContext, IRandomDataGenerator randomDataGenerator, ILogger logger)
            : base(companyEntitiesDbContext, randomDataGenerator, logger)
        {
        }

        public override void Generate(int countToGenerate)
        {
            this.Logger.Log("Generating Employees\n");

            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();

            var managerCount = 0.95 * countToGenerate;
            var employeesCount = countToGenerate - managerCount;

            // all the managers will be generated seperatly and added as they are attached to the employees
            var allManagers = new List<Employee>();
            for (int i = 0; i < managerCount; i++)
            {
                allManagers.Add(new Employee()
                {
                    FirstName = this.Random.GetString(5, 20),
                    LastName = this.Random.GetString(5, 20),
                    YearSalary = this.Random.GetInt(50000, 200000),
                    DepartmentId = departmentIds[this.Random.GetInt(0, departmentIds.Count - 1)]
                });
            }

            for (int i = 0; i < employeesCount; i++)
            {
                var employee = new Employee() 
                {
                    FirstName = this.Random.GetString(5, 20),
                    LastName = this.Random.GetString(5, 20),
                    YearSalary = this.Random.GetInt(50000, 200000),
                    DepartmentId = departmentIds[this.Random.GetInt(0, departmentIds.Count - 1)],
                    Employee1 = allManagers[this.Random.GetInt(0, allManagers.Count - 1)] // autogenerated code :(
                };

                this.Database.Employees.Add(employee);

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
