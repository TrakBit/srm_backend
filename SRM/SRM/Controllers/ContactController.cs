using SRM.Models;
using SRM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SRM.Controllers
{
    public class ContactController: ApiController
    {
        static readonly IContactRepository repository = new ContactRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Contact>GetAllContacts()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetContacts(int id)
        {
            Contact contact = repository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.Add(contact);
            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveContact(int id)
        {
            Contact contact = repository.Remove(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut]
        public IHttpActionResult UpdateCompany(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != contact.ContactId)
            {
                return BadRequest();
            }
            repository.Update(id, contact);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}