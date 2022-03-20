using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface IAccountRoleRepository : IRepository<AccountRole>
    {
        Task<AccountRole> GetAccountRoleById(int id);
    }
}
