namespace MusicStore.Data
{
    using MusicStore.Data.Repositories;
    using MusicStore.Models;

    public interface IMusicStoreData
    {
        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Album> Albums { get; }

        void SaveChanges();
    }
}
