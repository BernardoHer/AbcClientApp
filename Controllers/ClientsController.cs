using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbcClientApi.Context;
using AbcClientApi.Models;

namespace AbcClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientInfo>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInfo>> GetClientInfo(int id)
        {
            var clientInfo = await _context.Clients.FindAsync(id);

            if (clientInfo == null)
            {
                return NotFound();
            }

            return clientInfo;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientInfo(int id, ClientInfo clientInfo)
        {
            if (id != clientInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientInfo>> PostClientInfo(ClientInfo clientInfo)
        {
            _context.Clients.Add(clientInfo);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetClientInfo", new { id = clientInfo.Id }, clientInfo);
            return CreatedAtAction(nameof(GetClientInfo), new { id = clientInfo.Id }, clientInfo);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientInfo(int id)
        {
            var clientInfo = await _context.Clients.FindAsync(id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clientInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientInfoExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
