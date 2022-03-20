using System.Threading.Tasks;

namespace TMSAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
