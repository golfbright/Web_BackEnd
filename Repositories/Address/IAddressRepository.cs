using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressById(int id);
    }
}
