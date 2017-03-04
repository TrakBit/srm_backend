using SRM.Models;
using SRM.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace SRM.Controllers
{
    public class ModuleController: ApiController
    {
        static readonly IModuleRepository repository = new ModuleRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Module> GetAllModules()
        {
            return repository.GetAll();
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetModules(int id)
        {
            Module module = repository.Get(id);
            if (module == null)
            {
                return NotFound();
            }
            return Ok(module); 
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.Add(module);
            return CreatedAtRoute("DefaultApi", new { id = module.ModuleId }, module);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveModule(int id)
        {
            Module module = repository.Remove(id);
            if (module == null)
            {
                return NotFound();
            }
            return Ok(module);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult updateModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != module.ModuleId)
            {
                return BadRequest();
            }
            repository.Update(module);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}