namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Models;
    using StudentsSystem.Data.Migrations;

    public class StudentsSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentsSystemDbContext()
            : base("StudentsSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
