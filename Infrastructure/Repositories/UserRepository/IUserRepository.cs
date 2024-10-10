using ViteNetCoreApp.Domain.Models.Models;
using static ViteNetCoreApp.Infrastructure.Repositories.GenericRepository.IGenericRepository;

namespace ViteNetCoreApp.Infrastructure.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);

    }
}
