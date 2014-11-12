namespace MusicStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Data;
    using MusicStore.Models;
    using MusicStore.Web.Models;

    public class SongsController : BaseApiController
    {
        public SongsController(IMusicStoreData dataToUse)
            : base(dataToUse)
        {
        }

        public SongsController()
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Songs.All().Select(SongDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return this.Ok(this.Data.Songs.SearchFor(s => s.Id == id).Select(SongDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] SongDataModel songModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var song = SongDataModel.FromModelToData(songModel);
            this.Data.Songs.Add(song);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), song);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] SongDataModel songModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var song = this.Data.Songs.SearchFor(s => s.Id == id).FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Invalid id");
            }

            song.Genre = string.IsNullOrEmpty(songModel.Genre) ? song.Genre : songModel.Genre;
            song.Title = string.IsNullOrEmpty(songModel.Title) ? song.Title : songModel.Title;
            song.Year = songModel.Year;

            this.Data.Songs.Update(song);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var song = this.Data.Songs.SearchFor(s => s.Id == id).FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Songs.Delete(song);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}