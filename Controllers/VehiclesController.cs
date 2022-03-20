using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.VehicleCommand;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly IVehicleRepository _VehicleRepository;
        private readonly IMediator _mediator;

        public VehiclesController(TMSContext context, IVehicleRepository VehicleRepository, IMediator mediator)
        {
            _context = context;
            _VehicleRepository = VehicleRepository;
            _mediator = mediator;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            return await _context.Vehicle.ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var Vehicle = await _context.Vehicle.FindAsync(id);

            if (Vehicle == null)
            {
                return NotFound();
            }

            return Vehicle;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
        {
            _VehicleRepository.Update(Vehicle);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vehicle  >> PostVehicle(SaveVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var Vehicle = await _context.Vehicle.FindAsync(id);
            if (Vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(Vehicle);
            await _context.SaveChangesAsync();

            return Vehicle;
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
