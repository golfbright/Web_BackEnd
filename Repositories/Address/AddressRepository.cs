using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly TMSContext _context;
        public AddressRepository(TMSContext context)
        {
            _context = context;
        }
        public Address Add(Address address)
        {
            return _context.Address.Add(address).Entity;
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
        }

        public void Delete(Address address)
        {
            _context.Address.Remove(address);
        }

        public async Task<Address> GetAddressById(int id)
        {
            var address = await _context.Address.FindAsync(id);

            return address;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
