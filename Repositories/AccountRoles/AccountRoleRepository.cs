using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        private readonly TMSContext _context;
        public AccountRoleRepository(TMSContext context)
        {
            _context = context;
        }
        public AccountRole Add(AccountRole accountRoles)
        {
            return _context.AccountRoles.Add(accountRoles).Entity;
        }

        public void Update(AccountRole accountRoles)
        {
            _context.Entry(accountRoles).State = EntityState.Modified;
        }

        public void Delete(AccountRole accountRoles)
        {
            _context.AccountRoles.Remove(accountRoles);
        }

        public async Task<AccountRole> GetAccountRoleById(int id)
        {
            var accountRoles = await _context.AccountRoles.FindAsync(id);

            return accountRoles;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
