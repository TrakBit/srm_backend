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
    public class DealController : ApiController
    {
        static readonly IDealRepository repository = new DealRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Deal> GetAllDeals()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetDeals(int id)
        {
            Deal deal = repository.Get(id);
            if (deal == null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddDeal(Deal deal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.Add(deal);
            return CreatedAtRoute("DefaultApi", new { id = deal.DealId }, deal);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveDeal(int id)
        {
            Deal deal = repository.Remove(id);
            if (deal == null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateDeal(int id, Deal deal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != deal.DealId)
            {
                return BadRequest();
            }
            repository.Update(deal);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}