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
    public class ClientsController : ControllerBase
    {
        private readonly tekusContext _context;

        public ClientsController(tekusContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Clients> GetClients()
        {
            return _context.Clients.ToList();
        }


        //GET: api/Clients/5
        [HttpGet("{id}", Name = "ClientCreated")]
        public IActionResult GetClients([FromRoute] int id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.ClientId == id);

            if(client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST: api/Clients
        [HttpPost]
        public IActionResult PostClients([FromBody] Clients Client)
        {

            if (ModelState.IsValid)
            {
                Client.TimeCreated = DateTime.Now;

                _context.Clients.Add(Client);
                _context.SaveChanges();

                //return new CreatedAtRouteResult("ClientCreated", new { id = Client.ClientId });
                return Ok(Client);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public IActionResult PutClients([FromRoute] int id, [FromBody] Clients Client)
        {

            if (id != Client.ClientId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client.TimeUpdated = DateTime.Now;

            _context.Entry(Client).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(Client);
        }

        

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClients([FromRoute] int id)
        {

            var client = _context.Clients.FirstOrDefault(x => x.ClientId == id);

            if(client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return Ok(client);
        }

        private bool ClientsExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}