namespace MusicStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Data;
    using MusicStore.Models;
    using MusicStore.Web.Models;

    public class ArtistsController : BaseApiController
    {
        public ArtistsController(IMusicStoreData dataToUse)
            : base(dataToUse)
        {
        }

        public ArtistsController()
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Artists.All().Select(ArtistDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return this.Ok(this.Data.Artists.SearchFor(a => a.Id == id).Select(ArtistDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ArtistDataModel artistModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var artist = ArtistDataModel.FromModelToData(artistModel);
            this.Data.Artists.Add(artist);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), artist);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]ArtistDataModel artistModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var artist = this.Data.Artists.SearchFor(a => a.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Invalid id");
            }

            artist.Country = string.IsNullOrEmpty(artistModel.Country) ? artist.Country : artistModel.Country;
            artist.Name = string.IsNullOrEmpty(artistModel.Name) ? artist.Name : artistModel.Name;
            artist.DateOfBirth = artistModel.DateOfBirth;

            this.Data.Artists.Update(artist);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.Data.Artists.SearchFor(a => a.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Artists.Delete(artist);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}