namespace MusicStore.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicStore.Models;

    public class ArtistDataModel
    {
        public static Func<Artist, ArtistDataModel> FromDataToModel
        {
            get
            {
                return a => new ArtistDataModel()
                {
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(al => al.Title)
                };
            }
        }

        public static Artist FromModelToData(ArtistDataModel model)
        {
            return new Artist()
            {
                Name = model.Name,
                Country = model.Country,
                DateOfBirth = model.DateOfBirth
            };
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual IEnumerable<string> Albums { get; set; }
    }
}