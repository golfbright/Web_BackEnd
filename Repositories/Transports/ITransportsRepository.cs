using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface ITransportsRepository : IRepository<Transports>
    {
        Task<Transports> GetTransportsById(int id);
    }
}
