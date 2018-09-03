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
    public class ServicesController : ControllerBase
    {
        private readonly tekusContext _context;

        public ServicesController(tekusContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public IEnumerable<Services> GetServices()
        {
            return _context.Services.ToList();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var services = await _context.Services.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public IActionResult PutServices([FromRoute] int id, [FromBody] Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(services).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(services);
        }

        // POST: api/Services
        [HttpPost]
        public IActionResult PostServices([FromBody] Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            services.TimeCreated = DateTime.Now;

            _context.Services.Add(services);
            _context.SaveChanges();

            return CreatedAtAction("GetServices", new { id = services.ServiceId }, services);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public IActionResult DeleteServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var services =  _context.Services.FirstOrDefault(x => x.ServiceId == id);
            if (services == null)
            {
                return NotFound();
            }

            _context.Services.Remove(services);
            _context.SaveChanges();

            return Ok(services);
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}