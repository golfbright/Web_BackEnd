using System.Threading.Tasks;
using TMSAPI.Models;

namespace TMSAPI.Repositories
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        Task<TaskList> GetTaskListById(int id);
    }
}
