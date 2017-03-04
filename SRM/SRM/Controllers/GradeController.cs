using SRM.Models;
using SRM.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace SRM.Controllers
{
    public class GradeController: ApiController
    {
        static readonly IGradeRepository repository = new GradeRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Grade> GetAllGrades()
        {
            return repository.GetAll();
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetGrades(int id)
        {
            Grade grade = repository.Get(id);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddGrade(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.Add(grade);
            return CreatedAtRoute("DefaultApi", new { id = grade.GradeId }, grade);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveGrade(int id)
        {
            Grade grade = repository.Remove(id);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult updateGrade(int id, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != grade.GradeId)
            {
                return BadRequest();
            }
            repository.Update(grade);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}