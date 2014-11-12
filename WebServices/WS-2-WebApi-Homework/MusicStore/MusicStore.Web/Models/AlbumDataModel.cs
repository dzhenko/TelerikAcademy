namespace MusicStore.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicStore.Models;

    public class AlbumDataModel
    {
        public static Func<Album, AlbumDataModel> FromDataToModel
        {
            get
            {
                return a => new AlbumDataModel()
                {
                    Artists = a.Artists.Select(ar => ar.Name),
                    Producer = a.Producer,
                    Songs = a.Songs.Select(s => s.Title),
                    Title = a.Title,
                    Year = a.Year
                };
            }
        }

        public static Album FromModelToData(AlbumDataModel model)
        {
            return new Album()
            {
                Producer = model.Producer,
                Title = model.Title,
                Year = model.Year
            };
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public virtual IEnumerable<string> Artists { get; set; }

        public virtual IEnumerable<string> Songs { get; set; }
    }
}