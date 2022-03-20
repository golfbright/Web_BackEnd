using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TMSContext _context;
        public AccountRepository(TMSContext context)
        {
            _context = context;
        }
        public Account Add(Account account)
        {
            return _context.Account.Add(account).Entity;
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
        }

        public void Delete(Account account)
        {
            _context.Account.Remove(account);
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account != null)
            {
                await _context.Entry(account).Collection(x => x.AccountRoles).LoadAsync();
            }

            return account;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void RemoveRole(AccountRole removeItem)
        {
            _context.AccountRoles.Remove(removeItem);
        }

    }
}
