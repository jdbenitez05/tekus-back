using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tekus.Models;

namespace Tekus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesClientsController : ControllerBase
    {
        private readonly tekusContext _context;

        public ServicesClientsController(tekusContext context)
        {
            _context = context;
        }

        // GET: api/ServicesClients
        [HttpGet]
        public IEnumerable<ServicesClient> GetServicesClient()
        {
            return _context.ServicesClient.Include(x => x.Client).Include(x => x.Service).ToList();
        }

        // GET: api/ServicesClients/5
        [HttpGet("{id}")]
        public IActionResult GetServicesClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicesClient = _context.ServicesClient.FirstOrDefault(x => x.ServiceClientId == id);

            if (servicesClient == null)
            {
                return NotFound();
            }

            return Ok(servicesClient);
        }

        // PUT: api/ServicesClients/5
        [HttpPut("{id}")]
        public IActionResult PutServicesClient([FromRoute] int id, [FromBody] ServicesClient servicesClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicesClient.ServiceClientId)
            {
                return BadRequest();
            }

            _context.Entry(servicesClient).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(servicesClient);
        }

        // POST: api/ServicesClients
        [HttpPost]
        public IActionResult PostServicesClient([FromBody] ServicesClient servicesClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServicesClient.Add(servicesClient);
            _context.SaveChangesAsync();

            return CreatedAtAction("GetServicesClient", new { id = servicesClient.ServiceClientId }, servicesClient);
        }

        // DELETE: api/ServicesClients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServicesClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicesClient = _context.ServicesClient.FirstOrDefault(x => x.ServiceClientId == id);
            if (servicesClient == null)
            {
                return NotFound();
            }

            _context.ServicesClient.Remove(servicesClient);
            _context.SaveChanges();

            return Ok(servicesClient);
        }

        private bool ServicesClientExists(int id)
        {
            return _context.ServicesClient.Any(e => e.ServiceClientId == id);
        }
    }
}