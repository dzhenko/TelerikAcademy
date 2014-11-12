namespace StudentsSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentsSystem.Data;
    using StudentsSystem.Models;
    using StudentsSystem.Web.Models;

    public class TestsController : BaseApiController
    {
        public TestsController(IStudentsSystemData dataToUse)
            : base(dataToUse)
        {
        }

        public TestsController()
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Tests.All().Select(TestDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return this.Ok(this.Data.Tests.SearchFor(t => t.Id == id).Select(TestDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] TestDataModel testModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var course = this.Data.Courses.SearchFor(c => c.Name == testModel.Course).FirstOrDefault();

            if (course == null)
	        {
		        return this.BadRequest("Invalid course name");
	        }

            var test = TestDataModel.FromModelToData(testModel, course);
            this.Data.Tests.Add(test);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), test);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] TestDataModel testModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var test = this.Data.Tests.SearchFor(t => t.Id == id).FirstOrDefault();

            if (test == null)
            {
                return this.BadRequest("Invalid id");
            }

            var course = this.Data.Courses.SearchFor(c => c.Name == testModel.Course).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid course name");
            }

            test.Course = course;

            this.Data.Tests.Update(test);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var test = this.Data.Tests.SearchFor(t => t.Id == id).FirstOrDefault();

            if (test == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Tests.Delete(test);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}