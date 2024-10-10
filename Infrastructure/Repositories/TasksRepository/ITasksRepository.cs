using ViteNetCoreApp.Domain.Models.Models;
using static ViteNetCoreApp.Infrastructure.Repositories.GenericRepository.IGenericRepository;

namespace ViteNetCoreApp.Infrastructure.Repositories.TasksRepository
{
    public interface ITasksRepository : IGenericRepository<Tasks>
    {
        Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(int id);
    }
}
