using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetRoleById(int id);
    }
}
