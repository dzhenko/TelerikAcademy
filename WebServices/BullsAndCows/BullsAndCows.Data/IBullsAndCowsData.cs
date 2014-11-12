namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Guess> Guesses { get; }

        int SaveChanges();
    }
}
