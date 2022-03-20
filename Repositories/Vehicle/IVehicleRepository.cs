using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle> GetVehicleById(int id);
    }
}
