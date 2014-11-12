namespace StudentsSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentsSystem.Data;
    using StudentsSystem.Models;
    using StudentsSystem.Web.Models;

    public class CoursesController : BaseApiController
    {
        public CoursesController(IStudentsSystemData dataToUse)
            : base(dataToUse)
        {
        }

        public CoursesController()
            : base(new StudentsSystemData())
        {
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Courses.All().Select(CourseDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(string id)
        {
            return this.Ok(this.Data.Courses.SearchFor(c => c.Id.ToString() == id).Select(CourseDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CourseDataModel courseModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var course = CourseDataModel.FromModelToData(courseModel);
            this.Data.Courses.Add(course);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), course);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] CourseDataModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var course = this.Data.Courses.SearchFor(c => c.Id.ToString() == id).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid id");
            }

            course.Description = string.IsNullOrEmpty(courseModel.Description) ? course.Description : courseModel.Description;
            course.Name = string.IsNullOrEmpty(courseModel.Name) ? course.Name : courseModel.Name;

            this.Data.Courses.Update(course);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var course = this.Data.Courses.SearchFor(c => c.Id.ToString() == id).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}