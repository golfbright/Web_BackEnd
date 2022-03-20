using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMSAPI.Models;


namespace TMSAPI.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly TMSContext _context;
        public TaskListRepository(TMSContext context)
        {
            _context = context;
        }
        public TaskList Add(TaskList taskList)
        {
            return _context.TaskList.Add(taskList).Entity;
        }

        public void Update(TaskList taskList)
        {
            _context.Entry(taskList).State = EntityState.Modified;
        }

        public void Delete(TaskList taskList)
        {
            _context.TaskList.Remove(taskList);
        }

        public async Task<TaskList> GetTaskListById(int id)
        {
            var taskList = await _context.TaskList.FindAsync(id);

            return taskList;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
