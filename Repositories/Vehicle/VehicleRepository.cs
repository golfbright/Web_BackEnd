using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TMSContext _context;
        public VehicleRepository(TMSContext context)
        {
            _context = context;
        }
        public Vehicle Add(Vehicle Vehicle)
        {
            return _context.Vehicle.Add(Vehicle).Entity;
        }

        public void Update(Vehicle Vehicle)
        {
            _context.Entry(Vehicle).State = EntityState.Modified;
        }

        public void Delete(Vehicle Vehicle)
        {
            _context.Vehicle.Remove(Vehicle);
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            var Vehicle = await _context.Vehicle.FindAsync(id);

            return Vehicle;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}