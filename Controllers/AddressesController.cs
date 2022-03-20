using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.AddressCommand;
using TMSAPI.Models;
using TMSAPI.Queries;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly IAddressRepository _addressRepository;
        private readonly IMediator _mediator;
        private readonly ITMSQueries _TMSQueries;

        public AddressesController(TMSContext context, IAddressRepository addressRepository, IMediator mediator, ITMSQueries tmsQueries)
        {
            _context = context;
            _addressRepository = addressRepository;
            _mediator = mediator;
            _TMSQueries = tmsQueries;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            var allAddressResult = await _TMSQueries.GetAddressListByAsync();
            return Ok(allAddressResult);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            //var addressById = await _TMSQueries.GetAddressById(id);
            //return Ok(addressById);

            var Address = await _context.Address.FindAsync(id);

            if (Address == null)
            {
                return NotFound();
            }
            return Address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            _addressRepository.Update(address);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(SaveAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }
        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
