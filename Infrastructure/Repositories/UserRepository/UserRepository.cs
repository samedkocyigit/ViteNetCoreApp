using Microsoft.EntityFrameworkCore;
using ViteNetCoreApp.Infrastructure.Repositories;
using ViteNetCoreApp.Domain.Models.Models;
using ViteNetCoreApp.Exceptions;
using ViteNetCoreApp.Infrastructure.Repositories.GenericRepository;

namespace ViteNetCoreApp.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ToDoAppContext _context;
        public UserRepository(ToDoAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
