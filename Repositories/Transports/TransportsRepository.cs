using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class TransportsRepository : ITransportsRepository
    {
        private readonly TMSContext _context;
        public TransportsRepository(TMSContext context)
        {
            _context = context;
        }
        public Transports Add(Transports transport)
        {
            return _context.Transport.Add(transport).Entity;
        }

        public void Update(Transports transport)
        {
            _context.Entry(transport).State = EntityState.Modified;
        }

        public void Delete(Transports transport)
        {
            _context.Transport.Remove(transport);
        }

        public async Task<Transports> GetTransportsById(int id)
        {
            var transport = await _context.Transport.FindAsync(id);

            return transport;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
