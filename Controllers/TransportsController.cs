using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.TransportsCommand;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly ITransportsRepository _transportRepository;
        private readonly IMediator _mediator;

        public TransportsController(TMSContext context, ITransportsRepository transportRepository, IMediator mediator)
        {
            _context = context;
            _transportRepository = transportRepository;
            _mediator = mediator;
        }

        // GET: api/Transports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transports>>> GetTransport()
        {
            return await _context.Transport.ToListAsync();
        }

        // GET: api/Transports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transports>> GetTransport(int id)
        {
            var transport = await _context.Transport.FindAsync(id);

            if (transport == null)
            {
                return NotFound();
            }

            return transport;
        }

        // PUT: api/Transports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransport(int id, Transports transport)
        {
            _transportRepository.Update(transport);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Transports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transports>> PostTransport(SaveTransportsCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        // DELETE: api/Transports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transports>> DeleteTransport(int id)
        {
            var transport = await _context.Transport.FindAsync(id);
            if (transport == null)
            {
                return NotFound();
            }

            _context.Transport.Remove(transport);
            await _context.SaveChangesAsync();

            return transport;
        }

        private bool TransportExists(int id)
        {
            return _context.Transport.Any(e => e.Id == id);
        }
    }
}
