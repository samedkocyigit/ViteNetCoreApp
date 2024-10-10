using ViteNetCoreApp.Domain.Models.DTOs;

namespace ViteNetCoreApp.Domain.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserDto> Register(UserRegisterDto userRegisterDto);
        Task<LoginResponseDto> Login(UserLoginDto userLoginDto);
        Task Logout();
    }

}
