using System.Collections.Generic;
using System.Threading.Tasks;
using static ViteNetCoreApp.Infrastructure.Repositories.GenericRepository.IGenericRepository;
using AutoMapper;
using ViteNetCoreApp.Domain.Models.DTOs;
using ViteNetCoreApp.Domain.Models.Models;
using ViteNetCoreApp.Infrastructure.Repositories.UserRepository;
using ViteNetCoreApp.Exceptions;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> AddUserAsync(UserRegisterDto userRegisterDto)
    {
        var userExists = await _userRepository.GetUserByUsernameAsync(userRegisterDto.Username);
        if (userExists != null)
            throw new ErrorExceptions("User already exists!");

        var user= _mapper.Map<User>(userRegisterDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);


        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetUserByUsernameAsync(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        return _mapper.Map<UserDto>(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }
}
