using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface IAccountRepository: IRepository<Account>
    {
        Task<Account> GetAccountById(int id);
    }
}
