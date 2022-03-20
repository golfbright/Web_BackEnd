using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TMSContext _context;
        public RoleRepository(TMSContext context)
        {
            _context = context;
        }
        public Role Add(Role role)
        {
            return _context.Role.Add(role).Entity;
        }

        public void Update(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public void Delete(Role role)
        {
            _context.Role.Remove(role);
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _context.Role.FindAsync(id);

            return role;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
