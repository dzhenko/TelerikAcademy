namespace MusicStore.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicStore.Models;

    public class SongDataModel
    {
        public static Func<Song, SongDataModel> FromDataToModel
        {
            get
            {
                return a => new SongDataModel()
                {
                    Album = a.Album.Title,
                    Artist = a.Artist.Name,
                    Genre = a.Genre,
                    Title = a.Title,
                    Year = a.Year
                };
            }
        }

        public static Song FromModelToData(SongDataModel model)
        {
            return new Song()
            {
                Genre = model.Genre,
                Title = model.Title,
                Year = model.Year
            };
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}