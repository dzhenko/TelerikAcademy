namespace StudentsSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentsSystem.Data;
    using StudentsSystem.Models;
    using StudentsSystem.Web.Models;

    public class StudentsController : BaseApiController
    {
        public StudentsController(IStudentsSystemData dataToUse)
            : base(dataToUse)
        {
        }

        public StudentsController()
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Students.All().Select(StudentDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return this.Ok(this.Data.Students.SearchFor(c => c.StudentIdentification == id).Select(StudentDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] StudentDataModel studentModel)
        {
            if (!ModelState.IsValid)
	        {
                return this.BadRequest(ModelState);
	        }

            var student = StudentDataModel.FromModelToData(studentModel);
            this.Data.Students.Add(student);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), student);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] StudentDataModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var student = this.Data.Students.SearchFor(s => s.StudentIdentification == id).FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Invalid id");
            }

            student.AdditionalInformation.Email = string.IsNullOrEmpty(studentModel.Email) ? student.AdditionalInformation.Email : studentModel.Email;
            student.AdditionalInformation.Address = string.IsNullOrEmpty(studentModel.Address) ? student.AdditionalInformation.Address : studentModel.Address;

            this.Data.Students.Update(student);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var student = this.Data.Students.SearchFor(s => s.StudentIdentification == id).FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Students.Delete(student);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}