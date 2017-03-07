using SRM.Models;
using SRM.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace SRM.Controllers
{
    public class CourseController : ApiController
    {
        readonly ICourseRepository repository = new CourseRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Course> GetAllCourse()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = repository.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.Add(course);
            return CreatedAtRoute("DefaultApi", new { id = course.CourseId }, course);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveCourse(int id)
        {
            Course course = repository.Remove(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != course.CourseId)
            {
                return BadRequest();
            }
            repository.Update(course);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}