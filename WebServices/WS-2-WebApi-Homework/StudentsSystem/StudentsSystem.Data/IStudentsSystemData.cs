namespace StudentsSystem.Data
{
    using StudentsSystem.Data.Repositories;
    using StudentsSystem.Models;

    public interface IStudentsSystemData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Student> Students { get; }

        IGenericRepository<Test> Tests { get; }

        void SaveChanges();
    }
}
