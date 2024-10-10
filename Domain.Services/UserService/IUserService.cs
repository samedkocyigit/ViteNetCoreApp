using System.Collections.Generic;
using System.Threading.Tasks;
using ViteNetCoreApp.Domain.Models.DTOs;
using ViteNetCoreApp.Domain.Models.Models;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> AddUserAsync(UserRegisterDto user);
    Task<UserDto> GetUserByUsernameAsync(string username);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);


}
