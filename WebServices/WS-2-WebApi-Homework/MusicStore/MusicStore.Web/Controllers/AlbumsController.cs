namespace MusicStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using MusicStore.Data;
    using MusicStore.Models;
    using MusicStore.Web.Models;

    public class AlbumsController : BaseApiController
    {
        public AlbumsController(IMusicStoreData dataToUse)
            : base(dataToUse)
        {
        }

        public AlbumsController()
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Albums.All().Select(AlbumDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return this.Ok(this.Data.Albums.SearchFor(a => a.Id == id).Select(AlbumDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AlbumDataModel albumModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var album = AlbumDataModel.FromModelToData(albumModel);
            this.Data.Albums.Add(album);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), album);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlbumDataModel albumModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var album = this.Data.Albums.SearchFor(a => a.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Invalid id");
            }

            album.Title = string.IsNullOrEmpty(albumModel.Title) ? album.Title : albumModel.Title;
            album.Producer = string.IsNullOrEmpty(albumModel.Producer) ? album.Producer : albumModel.Producer;
            album.Year = albumModel.Year;

            this.Data.Albums.Update(album);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.Data.Albums.SearchFor(a => a.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Albums.Delete(album);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}