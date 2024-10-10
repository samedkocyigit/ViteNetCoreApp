using Microsoft.EntityFrameworkCore;
using ViteNetCoreApp.Infrastructure.Repositories;
using ViteNetCoreApp.Domain.Models.Models;
using ViteNetCoreApp.Exceptions;
using ViteNetCoreApp.Infrastructure.Repositories.GenericRepository;


namespace ViteNetCoreApp.Infrastructure.Repositories.TasksRepository
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        private readonly ToDoAppContext _context;
        public TasksRepository(ToDoAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _context.Tasks
                           .Where(t => t.UserId == userId)
                           .ToListAsync();
            if (tasks.Count == 0)
                throw new ErrorExceptions("There is no task with that userId ");



            return tasks;
        }
    }
}
